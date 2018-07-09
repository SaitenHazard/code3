using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDragControl : DragControls {

    private float delay;
    public InitiateDXBall initiateDXBall;

    void Awake()
    {
        delay = initiateDXBall.returnDelay();
    }

    void Start()
    {
        Invoke("IncrementSpeed", delay);
    }

    void IncrementSpeed()
    {
        speed += .2f;
        Invoke("IncrementSpeed", delay);
        Debug.Log(speed);
    }
}
