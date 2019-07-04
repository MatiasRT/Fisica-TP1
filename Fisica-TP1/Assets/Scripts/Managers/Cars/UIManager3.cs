using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager3 : MonoBehaviour
{
    private static UIManager3 instance;

    public static UIManager3 Instance
    {
        get
        {
            instance = FindObjectOfType<UIManager3>();
            if (instance == null)
            {
                GameObject go = new GameObject("UIManager3");
                instance = go.AddComponent<UIManager3>();
            }
            return instance;
        }
    }
    [SerializeField] Text scoreText;

    //GameObject car;
    //CarCPUMovement enemy;

    int score;
    float deltatimer;

    void Start()
    {
        //car = GameManager3.Instance.Enemy;
        scoreText.text = "SCORE:" + 0;
        score = 0;
        //enemy = GetComponent<CarCPUMovement>();
    }

    void Update()
    {
        deltatimer += Time.deltaTime;

        if (deltatimer > 1.5f)
        {
            score += 100;
            deltatimer = 0.0f;
        }
        scoreText.text = "SCORE:" + score;
    }
}
