﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] Wheel rightWheel;
    [SerializeField] Wheel leftWheel;
    [SerializeField] float actualSpeed;
    [SerializeField] float xLimit;
    [SerializeField] float yLimit;
    [SerializeField] float friction;
    [SerializeField] float acceleration;
    private float timer;
   
    void Update()
    {
        timer = Time.deltaTime;
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Z)){
            if (Input.GetKey(KeyCode.A))
                leftWheel.Speed += acceleration * timer;
            if (Input.GetKey(KeyCode.Z))
                leftWheel.Speed -= acceleration * timer;
        }
        else if(leftWheel.Speed != 0){
            leftWheel.Speed = Mathf.Lerp(leftWheel.Speed, 0, friction);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.C)){
            if (Input.GetKey(KeyCode.D))
                rightWheel.Speed += acceleration * timer;
            if (Input.GetKey(KeyCode.C))
                rightWheel.Speed -= acceleration * timer;
        }
        else if (rightWheel.Speed != 0){
            rightWheel.Speed = Mathf.Lerp(rightWheel.Speed, 0, friction );
        }

        if (leftWheel.TractionForce() == rightWheel.TractionForce()){
            transform.position = PhysicsLibrary.Movements.MRU(transform.position,Vector3.up, rightWheel.TractionForce());
        }else if(leftWheel.TractionForce() > rightWheel.TractionForce()){
            transform.position = PhysicsLibrary.Movements.MRU(transform.position, 
            Vector3.up + Vector3.left,
            leftWheel.TractionForce() + rightWheel.TractionForce());
        }
        else if (leftWheel.TractionForce() < rightWheel.TractionForce()){
            transform.position = PhysicsLibrary.Movements.MRU(transform.position, 
            Vector3.up + Vector3.right,
            rightWheel.TractionForce() + leftWheel.TractionForce());
        }
        if (transform.position.y > 0 && leftWheel.TractionForce() == 0 && rightWheel.TractionForce() == 0) { 
            transform.position = PhysicsLibrary.Movements.MRU(transform.position,Vector3.down,acceleration);
        }
    }
}