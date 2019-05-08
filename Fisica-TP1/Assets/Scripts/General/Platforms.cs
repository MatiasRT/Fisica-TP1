using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    CollisionManager cm;

    GameObject p1;

    Box platform;
    Box player;
    void Start()
    {
        cm = CollisionManager.Instance;
        p1 = GameManager2.Instance.Player;

        platform = gameObject.GetComponent<Box>();
        player = p1.GetComponent<Box>();
    }

   
    void Update()
    {
        CheckColl();
    }

    void CheckColl()
    {
        Debug.Log("Checking...");
        if (cm.CollisionDetector(platform, player))
        {
            Debug.Log("Colision!");
            p1.GetComponent<Movement>().Falling = false;
        } 
        else 
        {
            p1.GetComponent<Movement>().Falling = true;
        }
    }
}
