﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : GameManagerBase
{
    private DragControls dragLeftScript;
    private DragControls dragRightScript;
    public InitiateDXBall dxBallScript;

    private FacingDirections localFacing;

    public override void Awake()
    {
        dragLeftScript = characterLeft.GetComponent<DragControls>();
        dragRightScript = characterRight.GetComponent<DragControls>();

        base.Awake();
    }

    public override void ActivateScripts(bool activate)
    {
        dxBallScript.enabled = activate;

        if (characterLeft != null && characterLeft.activeInHierarchy)
        {
            dragLeftScript.enabled = activate;
        }

        if (characterRight != null && characterRight.activeInHierarchy)
        {
            dragRightScript.enabled = activate;
        }
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
            GameOver(false);
        }
        else
        {
            GameOver(true);
        }
    }
}