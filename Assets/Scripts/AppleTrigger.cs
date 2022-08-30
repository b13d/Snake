using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTrigger : MonoBehaviour
{
    int i;
    Score scoreGame;
    SnakeController snakeController;
    


    void Start()
    {
        scoreGame = FindObjectOfType(typeof(Score)) as Score;
        snakeController = FindObjectOfType(typeof(SnakeController)) as SnakeController;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (i > 0)
        {

        }
        else
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerTail")
            {
                scoreGame.SaveScore();
                snakeController.AddTail();
                Destroy(this.gameObject);
                i++;
            }
        }
            

    }
}
