using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateDXBall : MonoBehaviour {

    private Rigidbody2D rbBall;
    private float speed = 0.01f;
    private float delay = 1f;

    public Vector3 eye;

    void Awake ()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }
	
	void Start ()
    {
        InitiateVelocity();

        Invoke("FurhterVelocity", delay);
	}

    void InitiateVelocity()
    {
        Vector3 velocity = Random.onUnitSphere;

        rbBall.velocity = velocity;
        eye = rbBall.velocity;

    }

    void FurhterVelocity()
    {
        delay++;

        rbBall.velocity = rbBall.velocity + rbBall.velocity;
        eye = rbBall.velocity;

        if( Mathf.Abs(rbBall.velocity.x) < 8f && Mathf.Abs(rbBall.velocity.y ) < 8f)
            Invoke("FurhterVelocity", delay);
    }
}
