using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonGameSelect : EventTrigger
{
    public string SceneName;

    public override void OnPointerDown(PointerEventData data)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}

