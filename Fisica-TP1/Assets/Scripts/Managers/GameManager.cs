using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            instance = FindObjectOfType<GameManager>();
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                instance = go.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    float timer;
    float tTimer = 6.0f;

    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;

    [SerializeField] Text textPlayer;
    [SerializeField] Text textTimer;

    public GameObject PlayerOne
    {
        get { return playerOne; }
    }

    public GameObject PlayerTwo
    {
        get { return playerTwo; }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        tTimer -= Time.deltaTime;

        if(tTimer <= 1.0f)
            tTimer += 5.0f;

        ChangeTimerText(tTimer);
        DisableScripts();
    }

    void DisableScripts()
    {
        if (timer > 5.0f)
        {
            playerOne.GetComponent<TankP1Movement>().enabled = false;
            playerOne.GetComponent<CanonP1Movement>().enabled = true;
            ChangePlayerText("P1: Aim");
        }
        if (timer > 10.0f)
        {
            playerOne.GetComponent<CanonP1Movement>().enabled = false;
            playerOne.GetComponentInChildren<ShootP1>().enabled = true;
            ChangePlayerText("P1: Shoot");
        }
        if (timer > 15.0f)
        {
            playerOne.GetComponentInChildren<ShootP1>().enabled = false;
            playerTwo.GetComponent<TankP2Movement>().enabled = true;
            ChangePlayerText("P2: Move");
        }
        if (timer > 20.0f)
        {
            playerTwo.GetComponent<TankP2Movement>().enabled = false;
            playerTwo.GetComponent<CanonP2Movement>().enabled = true;
            ChangePlayerText("P2: Aim");
        }
        if (timer > 25.0f)
        {
            playerTwo.GetComponent<CanonP2Movement>().enabled = false;
            playerTwo.GetComponentInChildren<ShootP2>().enabled = true;
            ChangePlayerText("P2: Shoot");
        }
        if (timer > 30.0f)
        {
            playerTwo.GetComponentInChildren<ShootP2>().enabled = false;
            playerOne.GetComponent<TankP1Movement>().enabled = true;
            timer = 0.0f;
            ChangePlayerText("P1: Move");
        }
    }

    void ChangePlayerText(string newText)
    {
        textPlayer.text = newText;
    }

    void ChangeTimerText(float tTimer)
    {
        int time = (int)tTimer;
        textTimer.text = time.ToString();
    }
}
