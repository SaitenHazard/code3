using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBase : MonoBehaviour {
    public bool start = false;   
    private bool gameOver = false;

    public GameObject characterLeft;
    public GameObject characterRight;

    public GameObject gameOverState;
    private GameObject buttonHome;
    private GameObject spriteLeftWin;
    private GameObject spriteRightWin;
    private GameObject spriteLeftLoose;
    private GameObject spriteRightLoose;

    virtual public void Awake()
    {
        buttonHome = gameObject.transform.Find("ButtonHome").gameObject;
        spriteLeftWin = gameOverState.transform.Find("LeftWin").gameObject;
        spriteRightWin = gameOverState.transform.Find("RightWin").gameObject;
        spriteLeftLoose = gameOverState.transform.Find("LeftLoose").gameObject;
        spriteRightLoose = gameOverState.transform.Find("RightLoose").gameObject;
    }

    virtual public void Start()
    {
    }

    virtual public void UniqueGameOverHander(FacingDirections facing)
    {

    }

    virtual public void UniqueGameOverHander()
    {

    }

    virtual public void ActivateScripts(bool activate)
    {

    }

    virtual public void GameOver(bool leftWins)
    {
        if(characterLeft!=null)
            Destroy(characterLeft);

        if(characterRight!=null)
            Destroy(characterRight);

        buttonHome.SetActive(true);

        if(gameOver == false)
        {
            if (leftWins == true)
            {
                spriteLeftWin.SetActive(true);
                spriteRightLoose.SetActive(true);
            }
            else
            {
                spriteLeftLoose.SetActive(true);
                spriteRightWin.SetActive(true);
            }

            gameOver = true;
        }
    }
}
