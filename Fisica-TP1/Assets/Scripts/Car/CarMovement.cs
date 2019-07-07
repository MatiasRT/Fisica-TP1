using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    NEGATIVE = -1,
    NULL = 0,
    POSITIVE = 1,
}

public class CarMovement : MonoBehaviour
{
    [SerializeField] Wheel leftWheel;
    [SerializeField] Wheel rightWheel;

    CollisionManager cm;
    /*GameObject enemyCar;
    Box player;
    Box enemy;
    Health health;*/

    void Start()
    {
        cm = CollisionManager.Instance;

        /*enemyCar = GameManager3.Instance.Enemy;

        player = gameObject.GetComponent<Box>();
        enemy = enemyCar.GetComponent<Box>();
        health = player.GetComponent<Health>();*/
    }

    void Update()
    {
        switch ((int)Input.GetAxisRaw("RightWheel"))
        {
            case (int)State.POSITIVE:
                if (rightWheel.accel < rightWheel.maxAccel)
                    rightWheel.accel += Time.deltaTime;
                break;
            case (int)State.NEGATIVE:
                if (rightWheel.accel > -rightWheel.maxAccel)
                    rightWheel.accel -= Time.deltaTime;
                break;
            case (int)State.NULL:
                if (rightWheel.accel != 0.0f)
                    rightWheel.accel = (rightWheel.speed > 0.0f) ? -rightWheel.friction : rightWheel.friction;
                break;
        }

        switch ((int)Input.GetAxisRaw("LeftWheel"))
        {
            case (int)State.POSITIVE:
                if (leftWheel.accel < leftWheel.maxAccel)
                    leftWheel.accel += Time.deltaTime * 2.0f;
                break;
            case (int)State.NEGATIVE:
                if (leftWheel.accel > -leftWheel.maxAccel)
                    leftWheel.accel -= Time.deltaTime * 2.0f;
                break;
            case (int)State.NULL:
                if (leftWheel.accel != 0.0f)
                    leftWheel.accel = (leftWheel.speed > 0.0f) ? -leftWheel.friction : leftWheel.friction;
                break;
        }

        float minRightWheelSpeed = (rightWheel.accel == -rightWheel.friction) ? 0f : -rightWheel.maxSpeed;
        float minLeftWheelSpeed  = (leftWheel.accel  == -leftWheel.friction)  ? 0f : -leftWheel.maxSpeed;
        float maxRightWheelSpeed = (rightWheel.accel ==  rightWheel.friction) ? 0f :  rightWheel.maxSpeed;
        float maxLeftWheelSpeed  = (leftWheel.accel  ==  leftWheel.friction)  ? 0f :  leftWheel.maxSpeed;

        PhysicsLibrary.Movements.ConstantAcceleration(rightWheel.radius, rightWheel.accel, ref rightWheel.speed, minRightWheelSpeed, maxRightWheelSpeed);
        PhysicsLibrary.Movements.ConstantAcceleration(leftWheel.radius, leftWheel.accel, ref leftWheel.speed, minLeftWheelSpeed, maxLeftWheelSpeed);

        float carSpeedRight = rightWheel.radius * rightWheel.speed;
        float carSpeedLeft = leftWheel.radius * leftWheel.speed;

        Vector3 dirRight = Mathf.Sign(carSpeedRight) * transform.up + transform.right;
        if (rightWheel.speed < 0.0f)
        {
            dirRight.x *= -1.0f;
            dirRight.y *= -1.0f;
        } 
        dirRight.Normalize();
        
        Vector3 dirLeft = Mathf.Sign(carSpeedLeft) * transform.up - transform.right;
        if (leftWheel.speed < 0.0f)
        {
            dirLeft.x *= -1.0f;
            dirLeft.y *= -1.0f;
        }    
        dirLeft.Normalize();

        transform.position += PhysicsLibrary.Movements.NextPositionMRU(carSpeedLeft, dirLeft);
        transform.position += PhysicsLibrary.Movements.NextPositionMRU(carSpeedRight, dirRight);
    }

    /*void CheckCollision()
    {
        //Debug.Log("Checking...");
        if (cm.CollisionDetector(player, enemy))
        {
            //Debug.Log("Colision");
            //health.Lives -= 1;
        }
    }*/
}
