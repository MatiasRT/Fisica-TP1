using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float velInicial;
    [SerializeField] float vel;

    [SerializeField] float grav;

    bool fall;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal2");

        if (inputX > 0)
            transform.position = PhysicsLibrary.Movements.MRU(transform.position, velInicial, vel);

        if (inputX < 0)
            transform.position = PhysicsLibrary.Movements.MRU(transform.position, -velInicial, -vel);

        if (fall)
            transform.position = new Vector3(transform.position.x, transform.position.y - (grav * Time.deltaTime), 0);
    }

    public bool Falling{
        get { return fall; }
        set { fall = value;}
    }
}
