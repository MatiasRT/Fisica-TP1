using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] float spawnTime;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnTime);
    }

    void SpawnObject()
    {
        float randomPos = Random.Range(-5.0f, 5.0f);
        Vector3 pos = new Vector3(randomPos, 8.0f, 0);

        Instantiate(go, pos, Quaternion.identity);
    }
}