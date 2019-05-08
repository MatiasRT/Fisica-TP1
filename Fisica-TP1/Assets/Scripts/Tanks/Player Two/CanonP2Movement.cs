using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonP2Movement : MonoBehaviour
{
    [SerializeField] GameObject canon;
    [SerializeField] float speed;

    private void Update()
    {
        float inputY = Input.GetAxis("Vertical");

        canon.transform.Rotate(0, 0, -inputY * Time.deltaTime * speed);
    }
}
