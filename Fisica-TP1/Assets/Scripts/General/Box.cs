using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Vector2 position;
    public float width;
    public float height;

    void Update()
    {
        position = transform.position;
    }
}