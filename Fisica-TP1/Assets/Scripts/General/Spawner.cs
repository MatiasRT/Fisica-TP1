using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject background;
    [SerializeField] float spawnTimeEnemy;
    [SerializeField] float spawnTimeBgd;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTimeEnemy, spawnTimeEnemy);
        InvokeRepeating("SpawnBgd", spawnTimeBgd, spawnTimeBgd);
    }

    void SpawnEnemy()
    {
        float randomPos = Random.Range(-5.0f, 5.0f);
        Vector3 pos = new Vector3(randomPos, 8.0f, 0);

        Instantiate(enemy, pos, Quaternion.identity);
    }

    void SpawnBgd()
    {
        Vector3 pos = new Vector3(0.0f, 10.0f, 0);

        Instantiate(background, pos, Quaternion.identity);
    }
}