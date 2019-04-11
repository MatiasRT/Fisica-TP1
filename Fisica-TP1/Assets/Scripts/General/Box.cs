using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Vector2 box;
    public float width;
    public float height;

    void Start()
    {
        box = transform.position;
    }
}