using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    private static GameManager3 instance;

    public static GameManager3 Instance
    {
        get
        {
            instance = FindObjectOfType<GameManager3>();
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager3");
                instance = go.AddComponent<GameManager3>();
            }
            return instance;
        }
    }


    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    Health health;

    public GameObject Player
    {
        get { return player; }
    }

    public GameObject Enemy
    {
        get { return enemy; }
    }

    private void Start()
    {
        health = player.GetComponent<Health>();
    }

    private void Update()
    {
       
    }
}