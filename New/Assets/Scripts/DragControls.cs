using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControls : MonoBehaviour
{
    public FacingDirections facing;

    private Rigidbody2D rBody;
    private Vector2 touchPosition;
    private Vector2 touchPositionWorld;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdatePosition();
    }

    public FacingDirections getFacing()
    {
        return facing;
    }

    public FacingDirections GetFacing()
    {
        return facing;
    }

    void UpdatePosition()
    {
        touchPosition = getTouchPosition();

        if(touchPosition == Vector2.zero)
        {
            return;
        }

        touchPosition.x = rBody.transform.position.x;

        rBody.transform.position = Vector2.Lerp(rBody.transform.position, touchPosition, Time.deltaTime * 2);
    }

    public int getTouchDifference()
    {
        if (touchPosition == Vector2.zero || touchPositionWorld.y - rBody.transform.position.y == 0 || enabled == false)
        {
            return 0;
        }
        else if (touchPositionWorld.y - rBody.transform.position.y < 0)
        {
            return -1;

        }
        else
        {
            return 1;
        }
    }

    Vector2 getTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i<Input.touchCount; i++)
            {
                Touch touchInput = Input.GetTouch(i);
                Vector2 touchPositionScreen = touchInput.position;
                touchPositionWorld = Camera.main.ScreenToWorldPoint(touchPositionScreen);

                if(touchPositionWorld.x < 0 && facing==FacingDirections.Right)
                {
                    return touchPositionWorld;
                }

                if (touchPositionWorld.x > 0 && facing == FacingDirections.Left)
                {
                    return touchPositionWorld;
                }
            }
        }

        return Vector2.zero;
    }
}
