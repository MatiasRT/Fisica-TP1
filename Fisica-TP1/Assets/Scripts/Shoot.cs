using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform canon;

    void Start()
    {
        canon = GetComponent<Transform>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform tform = Instantiate(bullet, canon.transform.position, Quaternion.identity).transform;
            tform.eulerAngles += transform.eulerAngles;
            //Instantiate(bullet, canon.transform.position, Quaternion.identity);
            tform.GetComponent<BulletMovement>().CalculateVelocity(transform.eulerAngles.y);

            Debug.Log("crea bala");
        }
    }
}
