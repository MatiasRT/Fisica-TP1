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

        public static Vector3 MRU(Vector3 vec, Vector3 dir, float speed)
        {
            dir *= (speed * Time.deltaTime);
            vec += dir;
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

        public static Vector3 MCU(Vector3 center, float radio, float angle)
        {
            Vector3 nPos = ((radio * Mathf.Cos(angle) * Vector3.right) + (radio * Mathf.Sin(angle) * Vector3.up));
            nPos += center;
            return nPos;
        }

        public static float AngularVelocity(float angleI, float angleF, float timeI, float timeF)
        {
            float angle = angleI - angleF;
            float time = timeI - timeF;
            return angle / time;
        }
    }
}
