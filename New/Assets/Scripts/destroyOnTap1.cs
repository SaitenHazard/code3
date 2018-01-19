using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnTap1 : MonoBehaviour {
    
    private GenerateBubbles generateBubbles;
    public GameObject pinkPop;
    public GameObject bluePop;

    public GameObject playerLeft;
    public GameObject playerRight;

    private GameObject gameObject_m;
    private Animator animLeft, animRight;

    private void Awake()
    {
        generateBubbles = GetComponent<GenerateBubbles>();
        animLeft = playerLeft.GetComponentInChildren<Animator>();
        animRight = playerRight.GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        animRight.SetBool("Game3", true);
        animLeft.SetBool("Game3", true);
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
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), -Vector2.up);

                if (hit.collider != null)
                {
                    GameObject gameObject = hit.collider.gameObject;

                    if (gameObject.tag == "Bubble")
                    {
                        if (gameObject.transform.position.x < 0)
                        {
                            AnimateCharacter(playerLeft, hit.collider.transform, touch, animLeft);
                            InstantiatePop(bluePop);
                            generateBubbles.countBlue--;
                        }
                        else
                        {
                            AnimateCharacter(playerRight, hit.collider.transform, touch, animRight);
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

    void AnimateCharacter(GameObject Object, Transform tranform, Touch touch, Animator anim)
    {
        if(touch.phase == TouchPhase.Began)
        {
            (Object.GetComponent<Transform>()).position = new Vector3(0f, transform.position.x, 0f);
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            (Object.GetComponent<Transform>()).position = new Vector3(0f, 0f, 0f);
        }
    }

    void InstantiatePop(GameObject bubblePop)
    {
        Vector2 instantiateVector = new Vector2(gameObject_m.transform.position.x, gameObject_m.transform.position.x);

        Instantiate(bubblePop, instantiateVector, Quaternion.identity);

    }
}
