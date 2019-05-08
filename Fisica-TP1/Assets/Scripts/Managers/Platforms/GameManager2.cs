using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    private static GameManager2 instance;

    public static GameManager2 Instance
    {
        get
        {
            instance = FindObjectOfType<GameManager2>();
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager2");
                instance = go.AddComponent<GameManager2>();
            }
            return instance;
        }
    }

    [SerializeField] GameObject player;

    public GameObject Player
    {
        get { return player; }
    }

    private void Start()
    {
       
    }
}
