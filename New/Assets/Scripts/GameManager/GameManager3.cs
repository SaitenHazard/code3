using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : GameManagerBase
{
    public GenerateBubbles generateBubbles;

    private FacingDirections localFacing;

    public override void Awake()
    {
        base.Awake();
    }

    public override void ActivateScripts(bool activate)
    {
        generateBubbles.enabled = activate;
        base.DestroyTutorial();
    }

    public override void UniqueGameOverHander(FacingDirections facing)
    {
        localFacing = facing;
        ActivateScripts(false);

        GameObject[] bubbles;

        bubbles = GameObject.FindGameObjectsWithTag("Bubble");

        foreach (GameObject food in bubbles)
        {
            Destroy(food);
        }

        Invoke("InvokeGameOver", 1f);
    }

    void InvokeGameOver()
    {
        if (localFacing == FacingDirections.Left)
        {
            GameOver(true);
        }
        else
        {
            GameOver(false);
        }
    }
}
