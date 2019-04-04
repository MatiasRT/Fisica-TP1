using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] float velInicial;
    [SerializeField] float vel;
    [SerializeField] string input;

    void Update()
    {
        float inputX = Input.GetAxis(input);

        if (inputX > 0)
            transform.position = new Vector3(transform.position.x + (velInicial + (vel * Time.deltaTime)), transform.position.y, 0);

        if (inputX < 0)
            transform.position = new Vector3(transform.position.x - (velInicial + (vel * Time.deltaTime)),transform.position.y, 0);
    }
}