using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject background;
    
    [SerializeField] float spawnTimeBgd;

    void Awake()
    {
        InvokeRepeating("SpawnBgd", spawnTimeBgd, spawnTimeBgd);
    }
    
    void SpawnBgd()
    {
        Vector3 pos = new Vector3(0.0f, 10.0f, 0);
        Instantiate(background, pos, Quaternion.identity);
    }
}
