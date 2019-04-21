using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootP1 : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform canon;

    void Start()
    {
        //canon = GetComponent<Transform>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Transform tform = Instantiate(bullet, canon.transform.position, Quaternion.identity).transform;
            //Transform tform = Instantiate(bullet, canon.position, transform.rotation).transform;
            GameObject go = Instantiate(bullet, canon.position, transform.rotation);


            //tform.eulerAngles += transform.eulerAngles;
            //Instantiate(bullet, canon.transform.position, Quaternion.identity);
            //tform.GetComponent<BulletP1Movement>().Velocity(transform.eulerAngles.y);
        }
    }
}
