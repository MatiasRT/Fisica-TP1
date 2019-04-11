using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletP2Movement : MonoBehaviour
{
    [SerializeField] float velocity;

    float time;
    float grav = 9.8f;
    private Vector2 xyVelocity;

    private void Awake()
    {
        time = 0.0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        float mru = xyVelocity.x * Time.deltaTime;
        float shootFall = xyVelocity.y * Time.deltaTime + (-grav * Mathf.Sqrt(time)) * 0.5f * Time.deltaTime;

        transform.Translate(mru, shootFall, 0.0f);

        CheckBoundaries();
    }

    public void Velocity(float degree)
    {
        xyVelocity.x = velocity * Mathf.Cos(degree);
        xyVelocity.y = velocity * Mathf.Sin(degree);
    }

    void CheckBoundaries()
    {
        if (transform.position.x < -20.0f || transform.position.x > 20.0f
           || transform.position.y < -20.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
