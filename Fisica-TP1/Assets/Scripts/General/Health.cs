using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int lives;

    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }
}