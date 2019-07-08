using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
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

    private void Awake()
    {
        PhysicsLibrary.Collisions.CollisionManager cm = PhysicsLibrary.Collisions.CollisionManager.Instance;
    
        cm.SetRelation((int)PhysicsLibrary.Collisions.Elements.Player, (int)PhysicsLibrary.Collisions.Elements.Enemy);
        //colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Player, (int)Aleman5DLL.Collisions.Elements.Enviroment);
        //colMng.SetRelation((int)Aleman5DLL.Collisions.Elements.Enemy, (int)Aleman5DLL.Collisions.Elements.Enviroment);
    
    }

    private void Start()
    {
        health = player.GetComponent<Health>();
    }

    private void Update()
    {
       
    }
}