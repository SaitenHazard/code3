using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turorial1 : TutorialBase
{
    public override void playTutorial()
    {
        EnableAll(false);
    }

    void EnableAll(bool enable)
    {
        playButtonLeft.SetActive(enable);
        playButtonRight.SetActive(enable);
        sprite.enabled = enable;
        buttonTutorial.enabled = enable;
    }
}
