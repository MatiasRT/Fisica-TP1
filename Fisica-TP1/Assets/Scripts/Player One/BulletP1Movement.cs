using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletP1Movement : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float grav;
    float actualSpeed;
    Vector3 newPos;

    CollisionManager cm;
    GameObject p2;
    Box bullet;
    Box enemy;

    private void Start()
    {
        newPos = transform.position;
        actualSpeed = speed;

        cm = CollisionManager.Instance;
        p2 = GameManager.Instance.PlayerTwo;

        bullet = gameObject.GetComponent<Box>();
        enemy = p2.GetComponent<Box>();
    }

    void Update()
    {
        newPos = transform.position;

        float ang = transform.eulerAngles.z * Mathf.Deg2Rad;
        float vel = speed * Mathf.Cos(ang);
        newPos.x += vel * Time.deltaTime;

        float ang2 = transform.eulerAngles.z * Mathf.Deg2Rad;
        float vel2 = actualSpeed * Mathf.Sin(ang2);
        newPos.y += vel2 * Time.deltaTime - 0.5f * grav * Mathf.Sqrt(Time.deltaTime);
        actualSpeed -= grav;

        transform.position = newPos;

        CheckBoundaries();
        CheckColl();
    }

    void CheckBoundaries()
    {
        if (transform.position.x < -20.0f || transform.position.x > 20.0f
           || transform.position.y < -20.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void CheckColl()
    {
        Debug.Log("Checking...");
        if (cm.CollisionDetector(bullet, enemy))
        {
            Debug.Log("Colision!");
            Destroy(this.gameObject);
        }
    }
}
