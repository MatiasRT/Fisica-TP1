using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMovement : MonoBehaviour
{
    [SerializeField] GameObject canon;
    [SerializeField] string input;
    [SerializeField] float speed;

    private void Update()
    {
        float inputY = Input.GetAxis(input);

        canon.transform.Rotate(0, 0, -inputY * Time.deltaTime * speed);
    }
}
