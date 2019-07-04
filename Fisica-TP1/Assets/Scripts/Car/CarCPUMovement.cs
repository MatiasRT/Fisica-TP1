using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCPUMovement : MonoBehaviour
{
    [SerializeField] float velInicial;
    [SerializeField] float vel;

    bool death;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - (velInicial + (vel * Time.deltaTime)), 0);
    }

    void Update()
    {
        CheckBoundaries();
    }

    void CheckBoundaries()
    {
        if(transform.position.y < -8.0f)
        {
            Destroy(this.gameObject);
            death = true;
        }
        else
        {
            death = false;
        }
    }

    public bool Death
    {
        get { return death; }
        set { death = value; }
    }
}
