using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    SnakeController snakeController;

    public GameObject apple;
    int i,y;
    Vector3 scaleChangeUp, scaleChangeDown;
    // Start is called before the first frame update
    void Start()
    {
        snakeController = FindObjectOfType(typeof(SnakeController)) as SnakeController;

        scaleChangeUp = new Vector3(0.001f, 0.001f, 0.001f);
        scaleChangeDown = new Vector3(-0.001f, -0.001f, -0.001f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        createApple();
    }

    void createApple()
    {
        if (snakeController.isPlaying == true)
        {
            if (GameObject.FindGameObjectWithTag("Apple"))
            {
                // apple -> increases, decreases
                var apple = GameObject.FindGameObjectWithTag("Apple");

                if (apple.transform.localScale.x < 0.0650 && y == 0)
                {
                    apple.transform.localScale += scaleChangeUp;
                }
                else
                {
                    y = 1;
                }
                if (apple.transform.localScale.x > 0.0510 && y == 1)
                {
                    apple.transform.localScale += scaleChangeDown;
                }
                else
                {
                    y = 0;
                }
            }
            else
            {
                //checking the first apple that has fallen asleep
                var horizontal = Random.Range(-9.30f, 9.30f);
                var vertical = Random.Range(-5.60f, 4.70f);
                if (horizontal > 2.30 && horizontal < 4.30 && vertical > -2.70 && vertical < -0.50 && i == 0)
                {
                    horizontal = Random.Range(-9.30f, 9.30f);
                    vertical = Random.Range(-5.60f, 4.70f);
                }
                Instantiate(apple, new Vector3(horizontal, vertical), Quaternion.identity);

                i++; // the number of apples on the stage was
            }
        }
    }
}
