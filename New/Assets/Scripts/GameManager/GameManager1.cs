using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : GameManagerBase
{
    private DragControls dragLeftScript;
    private DragControls dragRightScript;
    private BubbleShoot bubbleShootLeft;
    private BubbleShoot bubbleShootRight;
    private Animator characterLeftAnim;
    private Animator characterRightAnim;

    private FacingDirections localFacing;

    public override void Awake()
    {
        dragLeftScript = characterLeft.GetComponent<DragControls>();
        bubbleShootLeft = characterLeft.GetComponent<BubbleShoot>();
        dragRightScript = characterRight.GetComponent<DragControls>();
        bubbleShootRight = characterRight.GetComponent<BubbleShoot>();
        characterLeftAnim = characterLeft.GetComponentInChildren<Animator>();
        characterRightAnim = characterRight.GetComponentInChildren<Animator>();

        base.Awake();
    }

    public override void ActivateScripts(bool activate)
    {
        if (characterLeft != null && characterLeft.activeInHierarchy)
        {
            dragLeftScript.enabled = activate;
            bubbleShootLeft.enabled = activate;
            characterRightAnim.SetBool("Walk", activate);

        }

        if (characterRight != null && characterRight.activeInHierarchy)
        {
            dragRightScript.enabled = activate;
            bubbleShootRight.enabled = activate;
            characterLeftAnim.SetBool("Walk", activate);
        }

        base.DestroyTutorial();
    }

    public override void UniqueGameOverHander(FacingDirections facing)
    {
        localFacing = facing;
        ActivateScripts(false);

        GameObject[] bubbles;

        bubbles = GameObject.FindGameObjectsWithTag("Bubble");

        foreach (GameObject bubble in bubbles)
        {
            Destroy(bubble);
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
