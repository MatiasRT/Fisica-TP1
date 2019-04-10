using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
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
        float shootFall = xyVelocity.y + (-grav * Mathf.Sqrt(time)) * 0.5f * Time.deltaTime;

        transform.Translate(mru, shootFall, 0.0f);
    }

    public void Velocity(float degree)
    {
        xyVelocity.x = velocity * Mathf.Cos(degree);
        xyVelocity.y = velocity * Mathf.Sin(degree);
    }
}
