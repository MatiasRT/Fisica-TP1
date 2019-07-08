using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovement : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject panelObject;
    [SerializeField] float spawnTime;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0.0f);

        if (transform.position.y < -46.0f)
        {
            //Debug.Log("Hola");
            Destroy(this.gameObject);
        }
    }
}