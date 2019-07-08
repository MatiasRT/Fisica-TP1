using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollision : PhysicsLibrary.Collisions.Box
{
    public override void OnCollision(PhysicsLibrary.Collisions.Box collision)
    {
        if (collision.GetTypeElem() == PhysicsLibrary.Collisions.Elements.Enemy)
            SceneManager.LoadScene(0);
    }
}
