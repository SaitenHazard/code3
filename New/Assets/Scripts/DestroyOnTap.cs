using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DestroyOnTap : MonoBehaviour
{
    private int localTouchCount;

	void Update ()
    {
        int i = 0;
        while (i < Input.touchCount)
        {

            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), -Vector2.up);

                Debug.Log("TAP !");

                if (hit.collider != null)
                {

                    if (hit.collider.tag == "BubblePink" || hit.collider.tag == "BubbleBlue")
                    {
                        Destroy(hit.collider.gameObject);
                    }

                }
            }

            ++i;
        }

    }
}
