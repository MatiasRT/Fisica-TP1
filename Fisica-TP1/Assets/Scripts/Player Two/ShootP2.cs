using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootP2 : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform canon;

    void Start()
    {
        //canon = GetComponent<Transform>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            /* Transform tform = Instantiate(bullet, canon.transform.position, Quaternion.identity).transform;
             tform.eulerAngles += transform.eulerAngles;
             //Instantiate(bullet, canon.transform.position, Quaternion.identity);
             tform.GetComponent<BulletP2Movement>().Velocity(transform.eulerAngles.y);*/

            GameObject go = Instantiate(bullet, canon.position, transform.rotation);
        }
    }
}
