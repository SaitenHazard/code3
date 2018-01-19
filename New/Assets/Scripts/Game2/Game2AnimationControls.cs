using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2AnimationControls : MonoBehaviour {

    private Animator anim;
    private FacingDirections facing;
    public DragControls dragControls;

    void Start()
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

    void Update()
    {
        ControlAnimation();
        //Fake();
    }
        
    void ControlAnimation()
    {
        anim.SetInteger("Game3AniController", dragControls.getTouchDifference());
    }
}
