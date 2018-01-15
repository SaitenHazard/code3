using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnTap1 : MonoBehaviour {
    
    private GenerateBubbles generateBubbles;
    public GameObject pinkPop;
    public GameObject bluePop;

    private GameObject gameObject_m;

    private void Awake()
    {
        generateBubbles = GetComponent<GenerateBubbles>();
    }

    void Update ()
    {
        tapHandler();
	}

    void tapHandler()
    {
        int i = 0;

        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), -Vector2.up);

                if (hit.collider != null)
                {
                    GameObject gameObject = hit.collider.gameObject;

                    if (gameObject.tag == "Bubble")
                    {
                        if (gameObject.transform.position.x < 0)
                        {
                            InstantiatePop(bluePop);
                            generateBubbles.countBlue--;
                        }
                        else
                        {
                            InstantiatePop(pinkPop);
                            generateBubbles.countPink--;
                        }

                        Destroy(gameObject);
                    }
                }
            }

            ++i;
        }
    }


    void InstantiatePop(GameObject bubblePop)
    {
        Vector2 instantiateVector = new Vector2(gameObject_m.transform.position.x, gameObject_m.transform.position.x);

        Instantiate(bubblePop, instantiateVector, Quaternion.identity);

    }
}
