using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTimeEnemy;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTimeEnemy, spawnTimeEnemy);
    }

    void SpawnEnemy()
    {
        float randomPos = Random.Range(-5.0f, 5.0f);
        Vector3 pos = new Vector3(randomPos, 8.0f, 0);

        Instantiate(enemy, pos, Quaternion.identity);
    }
}