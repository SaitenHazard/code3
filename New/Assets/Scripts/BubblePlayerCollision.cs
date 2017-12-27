using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlayerCollision : MonoBehaviour
{
    public Game1GameOverManager game1gameOverManager;
    public FacingDirections facing;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(facing==FacingDirections.Left)
        {
            game1gameOverManager.GameOver(true);
        }
        else
        {
            game1gameOverManager.GameOver(false);
        }
    }
}
