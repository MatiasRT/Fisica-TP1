using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletP1Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float grav;

    float velMru, velMruv;
    float actualSpeed;
    Vector3 newPos;

    CollisionManager cm;
    Health health;
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
        health = p2.GetComponent<Health>();
    }

    void Update()
    {
        newPos = transform.position;

        velMru = speed * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad);
        newPos.x += velMru * Time.deltaTime;

        velMruv = actualSpeed * Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad);
        newPos.y += velMruv * Time.deltaTime - 0.5f * grav * Mathf.Sqrt(Time.deltaTime);

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
            health.Lives -= 1;
            Debug.Log("Colision!");
            Destroy(this.gameObject);
        }
    }

    public float Speed
    {
        set { speed = value; }
    }
}
