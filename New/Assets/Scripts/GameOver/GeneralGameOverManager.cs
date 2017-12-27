using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralGameOverManager : MonoBehaviour
{
    public GameObject playerLeft, playerRight;
    public GameObject GameOverState;
    private GameObject buttonHome;
    private GameObject leftWin, rightwin, leftLoose, rightLoose;
    private bool localLeftWins;

    void Awake()
    {
        leftWin = GameOverState.transform.Find("LeftWin").gameObject;
        rightwin = GameOverState.transform.Find("RightWin").gameObject;
        rightLoose = GameOverState.transform.Find("RightLoose").gameObject;
        leftLoose = GameOverState.transform.Find("LeftLoose").gameObject;
        buttonHome = transform.Find("ButtonHome").gameObject;
    }

    public void gameOver(bool leftWins)
    {
        localLeftWins = leftWins;

        Invoke("ShowWinStates", 2);
    }

    void ShowWinStates()
    {
        if (!(playerLeft == null || playerLeft.Equals(null)))
            Destroy(playerLeft);

        if (!(playerRight == null || playerRight.Equals(null)))
            Destroy(playerRight);

        buttonHome.SetActive(true);

        if (localLeftWins == true)
        {
            leftWin.SetActive(true);
            rightLoose.SetActive(true);
        }
        else
        {
            leftLoose.SetActive(true);
            rightwin.SetActive(true);
        }
    }
}
