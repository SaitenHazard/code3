using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour {
    public bool b = false;

    public Game1ScriptList game1Scriptlist;

    public void EnableAllScripts()
    {
        game1Scriptlist.ScriptControl(true);
    }
}
