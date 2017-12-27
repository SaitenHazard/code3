using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1ScriptList : MonoBehaviour {

    public DragControls dragControlsLeft, dragControlsRight;
    public BubbleShoot bubbleShootLeft, bubbleShootRight;

    public void ScriptControl(bool enable)
    {
        dragControlsLeft.enabled = enable;
        dragControlsLeft.enabled = enable;
        bubbleShootLeft.enabled = enable;
        bubbleShootRight.enabled = enable;
    }
}
