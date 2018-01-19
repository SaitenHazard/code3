using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBubbleCollision : MonoBehaviour {

    public GameObject bubblePop;
    private BubblePlayerCollision bubblePlayerCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        InstantiatePop();

        if (collision.gameObject.tag == "Player")
            OnCollisionWithPlayer(collision.gameObject);

        Destroy(gameObject);
    }

    void OnCollisionWithPlayer(GameObject Object)
    {
        bubblePlayerCollision = Object.GetComponent<BubblePlayerCollision>();
        bubblePlayerCollision.onLoose();

    }

    void InstantiatePop()
    {
        Vector2 instantiateVector = new Vector2(transform.position.x, transform.position.x);

        Instantiate(bubblePop, instantiateVector, Quaternion.identity);
    }
}
