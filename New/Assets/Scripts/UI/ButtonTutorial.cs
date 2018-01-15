using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonTutorial : EventTrigger {

	public TutorialBase script;

    public override void OnPointerDown(PointerEventData eventData)
    {
        script.playTutorial();
    }
}
