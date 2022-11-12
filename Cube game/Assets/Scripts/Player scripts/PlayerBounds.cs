using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    // Maximum movement to right, left and down that indicates when the player will die
    public float min_X = -2.45f, max_X = 2.45f, min_Y = -5.6f;

    private bool out_Of_Bounds;

    void Update()
    {
        CheckBounds();
    }

    private void CheckBounds()
    {
        Vector2 temp = transform.position;

        //don't allow right movement beyond max
        if (temp.x > max_X)
        {
            temp.x = max_X;
        }
        //don't allow left movement beyond min
        if (temp.x < min_X)
        {
            temp.x = min_X;
        }

        // reset values back to current position of player 
        transform.position = temp;

        //if the player falls below then die
        if (temp.y <= min_Y)
        {
            if (!out_Of_Bounds)
            {
                //make value the opposite
                out_Of_Bounds = true;

                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
        }
    } // check bounds


    // check bounds with top spikes
    private void OnTriggerEnter2D(Collider2D target)
    {
        // if player hits top spikes then die
        if (target.tag == "TopSpikes")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.GameOverSound();
            GameManager.instance.RestartGame();
        }
    }



}
