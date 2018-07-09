using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControls : MonoBehaviour
{
    public FacingDirections facing;
    public float speed;

    public Rigidbody2D rBody;
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
        //touchPosition = getMousePosition();

        if(touchPosition == Vector2.zero)
        {
            return;
        }

        //Debug.Log("LOOK HERER" + rBody);
        touchPosition.x = rBody.transform.position.x;
        rBody.transform.position = Vector2.Lerp(rBody.transform.position, touchPosition, Time.deltaTime * speed);
    }

    Vector2 getMousePosition()
    {
        if (facing == FacingDirections.Left && Input.mousePosition.x < 0)
        {
            touchPositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return Input.mousePosition;
        }

        if (facing == FacingDirections.Right && Input.mousePosition.x > 0)
        {
            touchPositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return Input.mousePosition;
        }

        touchPositionWorld = Vector2.zero;
        return Vector2.zero;
    }

    Vector2 getTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touchInput = Input.GetTouch(i);
                Vector2 touchPositionScreen = touchInput.position;
                touchPositionWorld = Camera.main.ScreenToWorldPoint(touchPositionScreen);

                if (touchPositionWorld.x < 0 && facing == FacingDirections.Right)
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
}
