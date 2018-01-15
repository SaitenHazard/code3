using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopAnimationListener : MonoBehaviour {

    public void DestroyPop(AnimationEvent animationEvent)
    {
        Destroy(gameObject);
    }
}
