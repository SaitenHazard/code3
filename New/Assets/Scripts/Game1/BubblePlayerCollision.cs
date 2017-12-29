using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlayerCollision : MonoBehaviour
{
    public GameManagerBase gameManagerBase;
    public FacingDirections facing;

    public void OnDestroy()
    {
        gameManagerBase.UniqueGameOverHander(facing);
    }
}
