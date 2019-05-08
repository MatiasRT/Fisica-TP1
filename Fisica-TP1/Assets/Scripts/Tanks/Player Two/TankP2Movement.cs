using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankP2Movement : MonoBehaviour
{
    [SerializeField] float velInicial;
    [SerializeField] float vel;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (inputX > 0)
            transform.position = new Vector3(transform.position.x + (velInicial + (vel * Time.deltaTime)), transform.position.y, 0);

        if (inputX < 0)
            transform.position = new Vector3(transform.position.x - (velInicial + (vel * Time.deltaTime)),transform.position.y, 0);
    }
}