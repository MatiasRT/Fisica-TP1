using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private static CollisionManager instance;

    public static CollisionManager Instance
    {
        get
        {
            instance = FindObjectOfType<CollisionManager>();
            if (instance == null)
            {
                GameObject go = new GameObject("CollisionManager");
                instance = go.AddComponent<CollisionManager>();
            }
            return instance;
        }
    }

    public bool CollisionDetector(Box box1, Box box2)
    {
        Vector2 diff = box1.position - box2.position;

        float diffX = Mathf.Abs(diff.x);
        float diffY = Mathf.Abs(diff.y);

        if (diffX <= (box1.width / 2 + box2.width / 2) && diffY <= (box1.height / 2 + box2.height / 2))
        {
            return true;
        }
        else return false;
    }
}
