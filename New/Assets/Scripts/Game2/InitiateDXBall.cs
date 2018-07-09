using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateDXBall : MonoBehaviour {

    private Rigidbody2D rbBall;
    private float speed = 0.01f;
    private float delay;

    public Vector3 eye;

    void Awake ()
    {
        rbBall = GetComponent<Rigidbody2D>();
        delay = 0.5f;
    }

    public float returnDelay()
    {
        return delay;
    }
	
	void Start ()
    {
        InitiateVelocity();

        Invoke("FurhterVelocity", delay);
	}


    void InitiateVelocity()
    {
        Vector2 velocity;

        velocity.x = Random.Range(-1f, 1f);
        //velocity.x = 0f;
        velocity.y = Random.Range(-0.5f, 0.5f);
        //velocity.y = 0f;

        rbBall.velocity = velocity;
        eye = rbBall.velocity;

        Debug.Log(velocity);
    }

    void FurhterVelocity()
    {
        rbBall.velocity = rbBall.velocity + rbBall.velocity.normalized;
        eye = rbBall.velocity;

        float actualVelocity = Mathf.Sqrt(rbBall.velocity.x * rbBall.velocity.x + rbBall.velocity.y * rbBall.velocity.y);

        Debug.Log(actualVelocity);

        if (actualVelocity < 13f)
        {
            Invoke("FurhterVelocity", delay);
        }
    }

}
