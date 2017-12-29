using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonReady : EventTrigger
{
    public GameManagerBase gameManagerBase;

    public override void OnPointerDown(PointerEventData data)
    {
        if(gameManagerBase.start == false)
        {
            gameManagerBase.start = true;
        }
        else
        {
            gameManagerBase.ActivateScripts(true);
        }

        Destroy(gameObject);
    }
}
