using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    [SerializeField] float minRot;
    [SerializeField] float maxRot;

    private float x, y, z = 0;

    void Start()
    {
        x = transform.eulerAngles.x;
        y = transform.eulerAngles.y;
        z = Mathf.Clamp(transform.eulerAngles.z, minRot, maxRot);
        transform.eulerAngles= new Vector3(x,y,z);
    }

    void Update()
    {
        if(transform.eulerAngles.z > maxRot || transform.eulerAngles.z < minRot)
        {
            x = transform.eulerAngles.x;
            y = transform.eulerAngles.y;
            z = Mathf.Clamp(transform.eulerAngles.z, minRot, maxRot);
            transform.eulerAngles= new Vector3(x,y,z);
        }
    }
}
