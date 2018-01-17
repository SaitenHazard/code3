using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBase : MonoBehaviour {
    public bool start = false;   
    private bool gameOver = false;

    public GameObject characterLeft;
    public GameObject characterRight;
    public GameObject tutorialHolder;

    private GameObject buttonHome;

    private Animator leftAnimation;
    private Animator rightAnimation;

    virtual public void Awake()
    {
        buttonHome = gameObject.transform.Find("ButtonHome").gameObject;
        leftAnimation = characterLeft.GetComponentInChildren<Animator>();
        rightAnimation = characterRight.GetComponentInChildren<Animator>();

    }

    virtual public void setAnimationSet()
    {

    }

    virtual public void Start()
    {
    }

    virtual public void UniqueGameOverHander(FacingDirections facing)
    {

    }

    virtual public void DestroyTutorial()
    {
        if (tutorialHolder != null && tutorialHolder.activeInHierarchy)
        {
            Destroy(tutorialHolder);
        }

    }

    virtual public void UniqueGameOverHander()
    {

    }

    virtual public void ActivateScripts(bool activate)
    {
    }

    virtual public void GameOver(bool leftWins)
    {
        buttonHome.SetActive(true);

        if(gameOver == false)
        {
            if (leftWins == true)
            {
                leftAnimation.SetBool("Win", true);
                rightAnimation.SetBool("Loose", true);
            }
            else
            {
                leftAnimation.SetBool("Loose", true);
                rightAnimation.SetBool("Win", true);
            }

            gameOver = true;
        }
    }
}
