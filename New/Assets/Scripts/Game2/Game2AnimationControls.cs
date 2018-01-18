using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2AnimationControls : MonoBehaviour {

    private Animator anim;
    private FacingDirections facing;
    public DragControls dragControls;

	void Start ()
    {
        anim = GetComponentInChildren<Animator>();
        dragControls = GetComponent<DragControls>();
        facing = dragControls.getFacing();

        SetAnimationSet();
	}

    void SetAnimationSet()
    {
        anim.SetBool("Game2", true);
    }
	
	void Update ()
    {
        ControlAnimation();
	}

    void ControlAnimation()
    {
        if (dragControls.enabled == false)
        {
            anim.SetBool("Game2Up", false);
            anim.SetBool("Game2Down", false);
        }

        if (dragControls.getTouchDifference() == 1)
        {
            anim.SetBool("Game2Up", true);
            anim.SetBool("Game2Down", false);

        }
        else if (dragControls.getTouchDifference() == -1)
        {
            anim.SetBool("Game2Down", true);
            anim.SetBool("Game2Up", false);
        }
        else
        {
            anim.SetBool("Game2Up", false);
            anim.SetBool("Game2Down", false);
        }
    }
}
