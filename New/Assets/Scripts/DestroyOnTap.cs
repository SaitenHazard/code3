using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class DestroyOnTap : MonoBehaviour
{
    private int localTouchCount;

	void Update ()
    {
        localTouchCount = Input.touchCount;

        handleTouch();
    }

    void handleTouch()
    {
        Vector2[] touchPositions = getTouchPosition();

        if(touchPositions==null)
        {
            return;
        }

        RaycastHit2D[] hits = getHits(touchPositions);

        if (hits==null)
        {
            return;
        }

        GameObject[] objects = getObjects(hits);


        bubbleDestroyer(objects);

    }

    void bubbleDestroyer(GameObject[] objects)
    {
        for ( int i = 0; i<localTouchCount; i++)
        {
            if (objects[i] != null) Destroy(objects[i]);
        }
    }


    GameObject[] getObjects(RaycastHit2D[] hits)
    {
        GameObject[] objects = null;

        GameObject singleObject;

        for(int i = 0; i < localTouchCount; i++)
        {
            singleObject = hits[i].collider.gameObject;

            if (hits[i].collider.gameObject.tag=="Bubble")
            {
                objects[i] = singleObject;
            }
            else
            {
                objects[i] = null;
            }
        }

        return objects;
    }

    RaycastHit2D[] getHits(Vector2[] positionList)
    {
        RaycastHit2D [] hits = null;

        for(int i = 0; i < localTouchCount; i++)
        {
            hits[i] = Physics2D.Raycast(positionList[i], Vector2.zero);
        }

        return hits;
    }

    Vector2[] getTouchPosition()
    {
        Vector2[] positionList = null;

        if (localTouchCount>0)
        {
            positionList = new Vector2[localTouchCount];

            for (int i = 0; i < localTouchCount; i++)
            {
                Touch touchInput = Input.GetTouch(i);
                Vector2 touchPositionScreen = touchInput.position;
                Vector2 touchPositionWorld = Camera.main.ScreenToWorldPoint(touchPositionScreen);
                positionList[i] = touchPositionWorld;
            }

        }

        return positionList;
    }
}
