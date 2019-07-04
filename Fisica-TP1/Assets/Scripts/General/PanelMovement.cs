using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovement : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject panelObject;
    [SerializeField] float spawnTime;

    Vector2 panel;

    //[SerializeField] GameObject background;

    void Start()
    {
        //InvokeRepeating("CreatePanel", spawnTime, spawnTime);
        panel = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 0.0f);

        if (transform.position.y > -20.0f)
        {
            Debug.Log("Hola");
            //Destroy(this.gameObject);
        }
    }

    /*void CreatePanel()
    {
        //float randomPos = Random.Range(-5.0f, 5.0f);
        Vector3 pos = new Vector3(panel.x, panel.y + 10.0f, 0.0f);

        Instantiate(panelObject, pos, Quaternion.identity);
    }*/
}