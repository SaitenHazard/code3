using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateBubbles : MonoBehaviour {
    public GameManagerBase gameManagerBase;

    public GameObject bubblePink;
    public GameObject bubbleBlue;

    public int countBlue;
    public int countPink;

    private GameObject gObject;
    private Vector2 spawnPosition;
    private BubbleBubbleCollision bubbleBubbleCollision;

    private int count = 10;

	void Start ()
    {
        countBlue = count;
        countPink = count;
        Invoke("GenerateBubble", 2f);
    }

    void Update()
    {
        if(count==0) StateWinner();
    }

    //void tapHandler()
    //{
    //    int i = 0;

    //    while (i < Input.touchCount)
    //    {
    //        if (Input.GetTouch(i).phase == TouchPhase.Began)
    //        {
    //            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), -Vector2.up);

    //            if (hit.collider != null)
    //            {
    //                GameObject gameObject = hit.collider.gameObject;

    //                if (gameObject.tag == "Bubble")
    //                {
    //                    if (gameObject.transform.position.x < 0)
    //                    {
    //                        countBlue--;
    //                    }
    //                    else
    //                    {
    //                        countPink--;
    //                    }

    //                    Destroy(gameObject);
    //                }
    //            }
    //        }

    //        ++i;
    //    }

    //    //OnMouseDestroy();
    //}
    
    //void OnMouseDestroy()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

    //        if (hit.collider != null)
    //        {
    //            GameObject gameObject = hit.collider.gameObject;

    //            if (gameObject.tag == "Bubble")
    //            {
    //                if (gameObject.transform.position.x < 0)
    //                {
    //                    countBlue--;
    //                }
    //                else
    //                {
    //                    countPink--;
    //                }

    //                Destroy(gameObject);
    //            }
    //        }
    //    }
    //}

    void StateWinner()
    {
        if (countBlue == 0) gameManagerBase.UniqueGameOverHander(FacingDirections.Left);
        if (countPink == 0) gameManagerBase.UniqueGameOverHander(FacingDirections.Right);
    }

    void GenerateBubble()
    {
        count--;

        spawnPosition = new Vector2 (Random.Range(0.5f, 5f), Random.Range(-3.5f, 3.5f));
        gObject = Instantiate(bubblePink, spawnPosition, Quaternion.identity);
        bubbleBubbleCollision = gObject.GetComponent<BubbleBubbleCollision>();
        Destroy(bubbleBubbleCollision);

        spawnPosition = new Vector2(Random.Range(-0.5f, -5f), Random.Range(-3.5f, 3.5f));
        gObject = Instantiate(bubbleBlue, spawnPosition, Quaternion.identity);
        bubbleBubbleCollision = gObject.GetComponent<BubbleBubbleCollision>();
        Destroy(bubbleBubbleCollision);

        if (count==0) return;

        Invoke("GenerateBubble", .2f);
    }
}
