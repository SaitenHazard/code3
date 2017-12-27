using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1GameOverManager : MonoBehaviour
{
    public GameObject bubbleBlue, bubblePink;
    private GeneralGameOverManager generalGameOverManager;
    private Game1ScriptList scriptList;

    void Awake()
    {
        generalGameOverManager = GetComponent<GeneralGameOverManager>();
        scriptList = GetComponent<Game1ScriptList>();
    }

	public void GameOver(bool leftWins)
    {
        generalGameOverManager.gameOver(leftWins);
        scriptList.ScriptControl(false);
    }
}
