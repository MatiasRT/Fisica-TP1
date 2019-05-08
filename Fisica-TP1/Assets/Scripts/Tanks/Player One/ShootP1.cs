using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootP1 : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform canon;

    [SerializeField] bool shoot;

    private UIManager um;

    void Start()
    {
        shoot = true; 
        um = UIManager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shoot == true)
        {
            GameObject go = Instantiate(bullet, canon.position, transform.rotation);
            go.GetComponent<BulletP1Movement>().Speed = um.SliderP1;
            shoot = false;
        }
    }

    public bool CanShoot
    {
        get { return shoot; }
        set { shoot = value; }
    }
}