using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonReady : EventTrigger
{
    private StopTime script;

    void Awake()
    {
        script = GetComponentInParent<StopTime>();
    }

    public override void OnPointerDown(PointerEventData data)
    {
        if (script.b == false)
        {
            script.b = true;
        }
        else
        {
            script.EnableAllScripts();
        }

        Destroy(gameObject);
    }
}
