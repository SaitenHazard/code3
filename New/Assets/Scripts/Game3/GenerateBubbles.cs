using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBubbles : MonoBehaviour {

    public GameObject bubblePink;
    public GameObject bubbleBlue;

    public int countPinkDestroyed;
    public int countBlueDestroyed;

    private GameObject gObject;
    private Vector2 spawnPosition;
    private DestroyOnTap destoryOnTap;
    private BubbleBubbleCollision bubbleBubbleCollision;

    private int count = 20;

	void Start ()
    {
        countBlueDestroyed = count;
        countPinkDestroyed = count;
        Invoke("GenerateBubble", 2f);
    }

    void Update()
    {
        if(count==0) StateWinner();
    }

    void StateWinner()
    {
        if (countPinkDestroyed == 0) 
        if (countBlueDestroyed == 0)
    }


    void GenerateBubble()
    {
        count--;

        spawnPosition = new Vector2 (Random.Range(0.5f, 5f), Random.Range(-3.5f, 3.5f));
        gObject = Instantiate(bubblePink, spawnPosition, Quaternion.identity);
        destoryOnTap = gObject.GetComponent<DestroyOnTap>();
        bubbleBubbleCollision = gObject.GetComponent<BubbleBubbleCollision>();
        destoryOnTap.enabled = true;
        Destroy(bubbleBubbleCollision);

        spawnPosition = new Vector2(Random.Range(-0.5f, -5f), Random.Range(-3.5f, 3.5f));
        gObject = Instantiate(bubbleBlue, spawnPosition, Quaternion.identity);
        destoryOnTap = gObject.GetComponent<DestroyOnTap>();
        bubbleBubbleCollision = gObject.GetComponent<BubbleBubbleCollision>();
        destoryOnTap.enabled = true;
        Destroy(bubbleBubbleCollision);

        if (count==0) return;

        Invoke("GenerateTap", .2f);
    }
}
