using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DXLeaveScene : MonoBehaviour {

    public GameManagerBase gameManager2;
    public Sprite bubbleBlue, bubblePink;

    private SpriteRenderer rendered;
    private FacingDirections facing;

    void Awake()
    {
        rendered = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(transform.position.x<0f)
        {
            rendered.sprite = bubblePink;
            facing = FacingDirections.Left;
        }
        else
        {
            rendered.sprite = bubbleBlue;
            facing = FacingDirections.Left;
        }
    }

    void OnBecameInvisible()
    {
        gameManager2.UniqueGameOverHander(facing);
    }
}
