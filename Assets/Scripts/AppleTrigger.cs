using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTrigger : MonoBehaviour
{
    Score scoreGame;
    SnakeController snakeController;
    


    void Start()
    {
        scoreGame = FindObjectOfType(typeof(Score)) as Score;
        snakeController = FindObjectOfType(typeof(SnakeController)) as SnakeController;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            scoreGame.SaveScore();
            snakeController.AddTail();
            Destroy(this.gameObject);
        }
    }
}
