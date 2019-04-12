using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] TankP1Movement playerOneM;
    [SerializeField] CanonP1Movement playerOneC;
    [SerializeField] ShootP1 playerOneS;
    [SerializeField] TankP2Movement playerTwoM;
    [SerializeField] CanonP2Movement playerTwoC;
    [SerializeField] ShootP2 playerTwoS;
    [SerializeField] Text text;

    private void Start()
    {
        //playerOne = GetComponent<>   
        //playerOneC.GetComponent<CanonP1Movement>().enabled = false;
        //playerOneS.GetComponent<ShootP1>().enabled = false;
        //playerTwoM.GetComponent<TankP2Movement>().enabled = false;
        //playerTwoC.GetComponent<CanonP2Movement>().enabled = false;
        //playerTwoS.GetComponent<ShootP2>().enabled = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        DisableScripts();

        /*switch (timer)
        {
            case 10.0f:
                playerOneM.GetComponent<TankP1Movement>().enabled = false;
                playerOneC.GetComponent<CanonP1Movement>().enabled = true;
                break;
            case 20.0f:
                playerOneC.GetComponent<CanonP1Movement>().enabled = false;
                playerOneS.GetComponent<ShootP1>().enabled = true;
                break;
            case 25.0f:
                playerOneS.GetComponent<ShootP1>().enabled = false;
                playerTwoM.GetComponent<TankP2Movement>().enabled = true;
                break;
            case 30.0f:
                playerTwoM.GetComponent<TankP2Movement>().enabled = false;
                playerTwoC.GetComponent<CanonP2Movement>().enabled = true;
                break;
            case 40.0f:
                playerTwoC.GetComponent<CanonP2Movement>().enabled = false;
                playerTwoS.GetComponent<ShootP2>().enabled = true;
                break;
            case 45.0f:
                playerTwoS.GetComponent<ShootP2>().enabled = false;
                playerOneM.GetComponent<TankP1Movement>().enabled = true;
                timer = 0.0f;
                break;
        }*/
    }

    void DisableScripts()
    {
        if (timer > 5.0f)
        {
            playerOneM.GetComponent<TankP1Movement>().enabled = false;
            playerOneC.GetComponent<CanonP1Movement>().enabled = true;
            text.text = "P1: Aim";
        }
        if (timer > 10.0f)
        {
            playerOneC.GetComponent<CanonP1Movement>().enabled = false;
            playerOneS.GetComponent<ShootP1>().enabled = true;
            text.text = "P1: Shoot";
        }
        if (timer > 15.0f)
        {
            playerOneS.GetComponent<ShootP1>().enabled = false;
            playerTwoM.GetComponent<TankP2Movement>().enabled = true;
            text.text = "P2: Move";
        }
        if (timer > 20.0f)
        {
            playerTwoM.GetComponent<TankP2Movement>().enabled = false;
            playerTwoC.GetComponent<CanonP2Movement>().enabled = true;
            text.text = "P2: Aim";
        }
        if (timer > 25.0f)
        {
            playerTwoC.GetComponent<CanonP2Movement>().enabled = false;
            playerTwoS.GetComponent<ShootP2>().enabled = true;
            text.text = "P2: Shoot";
        }
        if (timer > 30.0f)
        {
            playerTwoS.GetComponent<ShootP2>().enabled = false;
            playerOneM.GetComponent<TankP1Movement>().enabled = true;
            timer = 0.0f;
            text.text = "P1: Move";
        }
    }
}
