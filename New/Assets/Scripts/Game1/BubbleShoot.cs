﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShoot : MonoBehaviour {

    public FacingDirections facing;
    public GameObject bubble;
    public GameObject bubblePop;

    private Rigidbody2D rBody;
    private float speed = 6f;

	void Awake ()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (facing == FacingDirections.Left)
            speed *= -1f;

        Invoke("Shoot", 0.75f);
    }

    void Shoot()
    {
        if(enabled==false)
        {
            return;
        }

        Vector2 instantiateVector;

        if (facing == FacingDirections.Right)
            instantiateVector = new Vector2(rBody.transform.position.x + 1.2f, rBody.transform.position.y);
        else
            instantiateVector = new Vector2(rBody.transform.position.x - 1.2f, rBody.transform.position.y);

        GameObject bubble_m = Instantiate(bubble, instantiateVector, Quaternion.identity);
            
        bubble_m.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);

        bubble_m.GetComponent<BubbleBubbleCollision>().bubblePop = bubblePop;

        Invoke("Shoot", 0.75f);
    }
}
