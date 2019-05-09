using System;
using UnityEngine;

namespace PhysicsLibrary
{
    public class Movements
    {
        public static Vector3 MRU(Vector3 vec, float velIni, float vel)
        {
            vec = new Vector3(vec.x + (velIni + (vel * Time.deltaTime)), vec.y, 0);
            return vec;
        }

        public static Vector3 ObliqueShoot(Vector3 vec, float speed, float gravity)
        {
            float velMru = speed * Mathf.Cos(vec.z * Mathf.Deg2Rad);
            vec.x += velMru * Time.deltaTime;

            float velMruv = speed * Mathf.Sin(vec.z * Mathf.Deg2Rad);
            vec.y += velMruv * Time.deltaTime - 0.5f * gravity * Mathf.Sqrt(Time.deltaTime);

            speed -= gravity;

            return vec;
        }

        public static void MCU()
        {
            // pos = posini + velAng * t
        }
    }
}
