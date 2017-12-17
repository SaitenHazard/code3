using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour {
    public bool b = false;

	void Start ()
    {
        Time.timeScale = 0f;
	}
}
