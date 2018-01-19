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

    void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (hit.collider != null)
            {
                Debug.Log("in");

                GameObject gameObject = hit.collider.gameObject;

                if (gameObject.tag == "Bubble")
                {
                    if (gameObject.transform.position.x < 0)
                    {
                        InstantiatePop(bluePop, gameObject.transform.position);
                        Destroy(gameObject);
                        //countBlue--;
                    }
                    else
                    {
                        InstantiatePop(pinkPop, gameObject.transform.position);
                        Destroy(gameObject);
                        //countPink--;
                    }

                    Destroy(gameObject);
                }
            }
        }
    }

    void FixedUpdate ()
    {
        tapHandler();
        //OnClick();
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

                            InstantiatePop(bluePop, gameObject.transform.position);
                            Destroy(gameObject);
                            AnimateCharacter(playerLeft, touch, animLeft);
                            generateBubbles.countBlue--;
                        }
                        else
                        {
                            InstantiatePop(pinkPop, gameObject.transform.position);
                            Destroy(gameObject);
                            AnimateCharacter(playerRight, touch, animRight);
                            generateBubbles.countPink--;
                        }
                    }
                }
            }

            ++i;
        }
    }

    void AnimateCharacter(GameObject Object, Touch touch, Animator anim)
    {
        Transform originalTransform = Object.transform;
        Vector2 touchPositionScreen = touch.position;
        Vector2 touchPositionWorld = Camera.main.ScreenToWorldPoint(touchPositionScreen);

        if (touch.phase == TouchPhase.Began)
        {
            originalTransform.position = new Vector3(originalTransform.position.x, touchPositionWorld.y, 0f);
            anim.SetBool("Walk", true);

        }

        StartCoroutine(MyFunction(Object, touch, anim));

        
    }

    IEnumerator MyFunction(GameObject Object, Touch touch, Animator anim)
    {
        yield return new WaitForSeconds(.2f);

        Transform originalTransform = Object.transform;
        originalTransform.position = new Vector3(originalTransform.position.x, 0f, 0f);
        anim.SetBool("Walk", false);
    }

    void InstantiatePop(GameObject bubblePop, Vector2 position)
    {
        Vector2 instantiateVector = new Vector2(position.x, position.y);

        Instantiate(bubblePop, instantiateVector, Quaternion.identity);

    }
}
