using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootP2 : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform canon;
    [SerializeField] bool shoot;

    private UIManager um;

    void Start()
    {
        shoot = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) && shoot == true)
        {
            GameObject go = Instantiate(bullet, canon.position, transform.rotation);
            go.GetComponent<BulletP2Movement>().Speed = um.SliderP2;
            shoot = false;
        }
    }

    public bool CanShoot
    {
        get { return shoot; }
        set { shoot = value; }
    }
}