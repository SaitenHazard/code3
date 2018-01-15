using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBase : MonoBehaviour {

    public GameObject playButtonLeft;
    public GameObject playButtonRight;

    public ButtonTutorial buttonTutorial;
    public SpriteRenderer sprite;

    virtual public void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    virtual public void playTutorial()
    {

    }
}
