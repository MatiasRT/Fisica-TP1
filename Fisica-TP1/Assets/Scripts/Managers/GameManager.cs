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

    float deltatimer;
    float tTimer = 6.0f;

    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;

    [SerializeField] Text textPlayer;
    [SerializeField] Text textTimer;

    Health healthP1;
    Health healthP2;
    ShootP1 shootP1;
    ShootP2 shootP2;

    public GameObject PlayerOne
    {
        get { return playerOne; }
    }

    public GameObject PlayerTwo
    {
        get { return playerTwo; }
    }

    private void Start()
    {
        healthP1 = playerOne.GetComponent<Health>();
        healthP2 = playerTwo.GetComponent<Health>();
        shootP1 = playerOne.GetComponentInChildren<ShootP1>();
        shootP2 = playerTwo.GetComponentInChildren<ShootP2>();
    }

    private void Update()
    {
        deltatimer += Time.deltaTime;
        tTimer -= Time.deltaTime;

        if(tTimer <= 1.0f)
            tTimer += 5.0f;

        if (healthP1.Lives == 0)
            Debug.Log("End Game: Winner p2");
        if (healthP2.Lives == 0)
            Debug.Log("End Game: Winner p1");

        ChangeTimerText(tTimer);
        DisableScripts();
    }

    void DisableScripts()
    {
        if (deltatimer > 5.0f)
        {
            playerOne.GetComponent<TankP1Movement>().enabled = false;
            playerOne.GetComponent<CanonP1Movement>().enabled = true;
            
            ChangePlayerText("P1: Aim");
        }
        if (deltatimer > 10.0f)
        {
            playerOne.GetComponent<CanonP1Movement>().enabled = false;
            playerOne.GetComponentInChildren<ShootP1>().enabled = true;
            ChangePlayerText("P1: Shoot");
        }
        if (deltatimer > 15.0f)
        {
            playerOne.GetComponentInChildren<ShootP1>().enabled = false;
            playerTwo.GetComponent<TankP2Movement>().enabled = true;
            ChangePlayerText("P2: Move");
        }
        if (deltatimer > 20.0f)
        {
            playerTwo.GetComponent<TankP2Movement>().enabled = false;
            playerTwo.GetComponent<CanonP2Movement>().enabled = true;
            
            ChangePlayerText("P2: Aim");
        }
        if (deltatimer > 25.0f)
        {
            playerTwo.GetComponent<CanonP2Movement>().enabled = false;
            playerTwo.GetComponentInChildren<ShootP2>().enabled = true;
            ChangePlayerText("P2: Shoot");
        }
        if (deltatimer > 30.0f)
        {
            playerTwo.GetComponentInChildren<ShootP2>().enabled = false;
            playerOne.GetComponent<TankP1Movement>().enabled = true;
            deltatimer = 0.0f;
            CanShoot();
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

    void CanShoot()
    {
        shootP1.CanShoot = true;
        shootP2.CanShoot = true;
    }
}
