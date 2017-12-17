using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControls : MonoBehaviour
{
    public FacingDirections facing;

    private Rigidbody2D rBody;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        Vector2 touchPosition = getTouchPosition();

        if(touchPosition == null)
        {
            return;
        }

        touchPosition.x = rBody.transform.position.x;

        rBody.transform.position = Vector2.Lerp(rBody.transform.position, touchPosition, Time.deltaTime * 2);
    }

    Vector2 getTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i<Input.touchCount; i++)
            {
                Touch touchInput = Input.GetTouch(i);
                Vector2 touchPositionScreen = touchInput.position;
                Vector2 touchPositionWorld = Camera.main.ScreenToWorldPoint(touchPositionScreen);

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
