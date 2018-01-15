using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBubbleCollision : MonoBehaviour {

    public GameObject bubblePop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        InstantiatePop();
        Destroy(collision.gameObject);
    }

    void InstantiatePop()
    {
        Vector2 instantiateVector = new Vector2(transform.position.x, transform.position.x);

        Instantiate(bubblePop, instantiateVector, Quaternion.identity);

    }
}
