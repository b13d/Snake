using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTrigger : MonoBehaviour
{
    int i;
    Score scoreGame;
    SnakeController snakeController;
    AudioSource audioSource;
    public AudioClip audioClip;
    ParticleSystem particleApple;
    GameObject particle;
    void Start()
    {
        particle = GameObject.Find("ParticleEat");
        particleApple = particle.GetComponent<ParticleSystem>();

        scoreGame = FindObjectOfType(typeof(Score)) as Score;
        snakeController = FindObjectOfType(typeof(SnakeController)) as SnakeController;
        audioSource = snakeController.GetComponent<AudioSource>();
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
                audioSource.PlayOneShot(audioClip);
                particle.transform.position = this.gameObject.transform.position;
                particleApple.Play();

                Destroy(this.gameObject);

                i++;
            }
        }
            

    }
}
