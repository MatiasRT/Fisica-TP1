using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    float wheelRadius = 2.0f;
    float angleI, angleF = 0;
    float timeI, timeF = 0;
    [SerializeField] float angleVel;
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxAngleVel;

    void Update()
    {
        angleI += Time.deltaTime * speed;
        timeI += Time.deltaTime;
        angleVel = PhysicsLibrary.Movements.AngularVelocity(angleI, angleF, timeI, timeF);
        angleF += Time.deltaTime * speed;
        timeF += Time.deltaTime;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        angleVel = Mathf.Clamp(angleVel, -maxAngleVel, maxAngleVel);    
    }

    public float TractionForce()
    {
        return (angleVel / wheelRadius);
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}
