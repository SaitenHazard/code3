using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonStartGame : EventTrigger
{
    private StopTime script;

    void Awake()
    {
        script = GetComponentInParent<StopTime>();
        Debug.Log(script);
    }

    public override void OnPointerDown(PointerEventData data)
    {
        if (script.b == false)
            script.b = true;
        else
            Time.timeScale = 1f;

        Destroy(gameObject);
    }
}
