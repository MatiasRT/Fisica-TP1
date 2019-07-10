using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum State
{
    POSITIVE = 1,
    NEGATIVE = -1,
    NULL = 0,
}

public class CarMovement : MonoBehaviour
{
    [SerializeField] Wheel leftWheel;
    [SerializeField] Wheel rightWheel;


    void Update()
    {
        float minRightWheelSpeed;
        float minLeftWheelSpeed;
        float maxRightWheelSpeed;
        float maxLeftWheelSpeed;
        float carSpeedRight;
        float carSpeedLeft;

        switch ((int)Input.GetAxisRaw("RightWheel"))
        {
            case (int)State.POSITIVE:                                               // Si se apreta D
                if (rightWheel.accel < rightWheel.maxAccel)                         // Si la rueda derecha no alcanzo la aceleracion maxima
                    rightWheel.accel += Time.deltaTime;                             // Sigue aumentando la aceleracion
                break;
            case (int)State.NEGATIVE:                                               // Si se apreta C
                if (rightWheel.accel > -rightWheel.maxAccel)                        // Si la rueda derecha no alcanzo la aceleracion maxima hacia atras
                    rightWheel.accel -= Time.deltaTime;                             // Sigue aumentando la aceleracion hacia atras
                break;
            case (int)State.NULL:                                                   // Si no se apreta nada
                if (rightWheel.accel != 0.0f)                                       // Si la aceleracion es diferente a 0 , hago que frene por la friccion de la rueda
                    rightWheel.accel = (rightWheel.speed > 0.0f) ? -rightWheel.friction : rightWheel.friction;
                break;
        }

        switch ((int)Input.GetAxisRaw("LeftWheel"))
        {
            case (int)State.POSITIVE:                                               // Si se apreta A
                if (leftWheel.accel < leftWheel.maxAccel)                           // Si la rueda izquierda no alcanzo la aceleracion maxima
                    leftWheel.accel += Time.deltaTime * 2.0f;                       // Sigue aumentando la aceleracion
                break;
            case (int)State.NEGATIVE:                                               // Si se apreta Z
                if (leftWheel.accel > -leftWheel.maxAccel)                          // Si la rueda izquierda no alcanzo la aceleracion maxima hacia atras
                    leftWheel.accel -= Time.deltaTime * 2.0f;                       // Sigue aumentando la aceleracion hacia atras
                break;
            case (int)State.NULL:                                                   // Si no se apreta nada
                if (leftWheel.accel != 0.0f)                                        // Si la aceleracion es diferente a 0 , hago que frene por la friccion de la rueda
                    leftWheel.accel = (leftWheel.speed > 0.0f) ? -leftWheel.friction : leftWheel.friction;
                break;
        }

        
        minRightWheelSpeed = (rightWheel.accel == -rightWheel.friction) ? 0f : -rightWheel.maxSpeed;    // Obtengo la minima velocidad de la rueda derecha
        maxRightWheelSpeed = (rightWheel.accel ==  rightWheel.friction) ? 0f :  rightWheel.maxSpeed;    // Obtengo la maxima velocidad de la rueda derecha   
        
        minLeftWheelSpeed  = (leftWheel.accel  == -leftWheel.friction)  ? 0f : -leftWheel.maxSpeed;     // Obtengo la minima velocidad de la rueda izquierda
        maxLeftWheelSpeed  = (leftWheel.accel  ==  leftWheel.friction)  ? 0f :  leftWheel.maxSpeed;     // Obtengo la maxima velocidad de la rueda izquierda

        PhysicsLibrary.Movements.ConstantAcceleration(rightWheel.radius, rightWheel.accel, ref rightWheel.speed, minRightWheelSpeed, maxRightWheelSpeed);
        PhysicsLibrary.Movements.ConstantAcceleration(leftWheel.radius, leftWheel.accel, ref leftWheel.speed, minLeftWheelSpeed, maxLeftWheelSpeed);

        carSpeedRight = rightWheel.radius * rightWheel.speed;
        carSpeedLeft = leftWheel.radius * leftWheel.speed;

        Vector3 dirRight = Mathf.Sign(carSpeedRight) * transform.up + transform.right;  // Obtengo el signo de la direccion derecha
        if (rightWheel.speed < 0.0f)    // Si la velocidad de la rueda es menor a 0, osea va para atras, invierto los signos para que se mueva correctamente
        {
            dirRight.x *= -1.0f;                                                        
            dirRight.y *= -1.0f;                                                        
        } 
        dirRight.Normalize();
        
        Vector3 dirLeft = Mathf.Sign(carSpeedLeft) * transform.up - transform.right;    // Obtengo el signo de la direccion izquierda
        if (leftWheel.speed < 0.0f)     // Si la velocidad de la rueda es menor a 0, osea va para atras, invierto los signos para que se mueva correctamente
        {
            dirLeft.x *= -1.0f;
            dirLeft.y *= -1.0f;
        }    
        dirLeft.Normalize();

        transform.position += PhysicsLibrary.Movements.NextPositionMRU(carSpeedLeft, dirLeft);
        transform.position += PhysicsLibrary.Movements.NextPositionMRU(carSpeedRight, dirRight);

        CheckSides();
    }

    void CheckSides()
    {
        if(transform.position.x < -9.0f || transform.position.x > 9.0f || transform.position.y < -5.0f || transform.position.y > 5.0f)
            SceneManager.LoadScene(0);
    }
}
