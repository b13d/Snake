using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameSettings : MonoBehaviour
{
    AudioSource music;
    SnakeController snakeController;

    void Awake()
    {
        music = GetComponent<AudioSource>();
        snakeController = FindObjectOfType(typeof(SnakeController)) as SnakeController;
        CameraSettings();
        StartingValues();
    }

    void StartingValues()
    {
        GameObject message = GameObject.Find("CanvasMessage");
        var parent = message.transform;
        parent = parent.Find("MenuMessage");


        var parentEsc = GameObject.Find("MenuMessageEsc");

        var parentGameObject = parent.gameObject;

        if (parentGameObject.active == true)
            parentGameObject.SetActive(false);

        if (parentEsc == true)
            parentEsc.SetActive(false);
    }

    void CameraSettings()
    {
        //var camera = GameObject.Find("Main Camera");
        var score = GameObject.Find("ScoreText");
        var scoreText = score.GetComponent<TextMeshProUGUI>();
        var record = GameObject.Find("RecordText");
        var recordText = record.GetComponent<TextMeshProUGUI>();

        if (Screen.width > 1280)
        {
            recordText.fontSize = 60;
            scoreText.fontSize = 60;
        }
        else if (Screen.width > 1279 && Screen.width > 1024)
        {
            recordText.fontSize = 45;
            scoreText.fontSize = 45;
        }
        else
        {
            recordText.fontSize = 25;
            scoreText.fontSize = 25;
        }
    }

    private void Update()
    {
        //music.Play();

        var score = GameObject.Find("ScoreText");
        var scoreText = score.GetComponent<TextMeshProUGUI>();
        var record = GameObject.Find("RecordText");
        var recordText = record.GetComponent<TextMeshProUGUI>();
        if (Screen.width > 1280)
        {
            recordText.fontSize = 60;
            scoreText.fontSize = 60;
        }
        else if(Screen.width > 1279 && Screen.width > 1024)
        {
            recordText.fontSize = 45;
            scoreText.fontSize = 45;
        }
        else
        {
            recordText.fontSize = 25;
            scoreText.fontSize = 25;
        }

        EscapeMenu();
    }

    void EscapeMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameObject.Find("MenuMessageEsc") == null)
            {
                GameObject message = GameObject.Find("CanvasMessageEsc");
                var parent = message.transform;
                parent = parent.Find("MenuMessageEsc");
                parent.gameObject.SetActive(true);

                var player = GameObject.FindGameObjectWithTag("Player");
                var playerRigidbody = player.GetComponent<Rigidbody>();
                playerRigidbody.Sleep();
                snakeController.isPlaying = false;
            }
            else
            {
                EscapeExitMenu();
            }

        }
    }

    public void EscapeExitMenu()
    {
        GameObject message = GameObject.Find("CanvasMessageEsc");
        var parent = message.transform;
        parent = parent.Find("MenuMessageEsc");
        parent.gameObject.SetActive(false);

        var player = GameObject.FindGameObjectWithTag("Player");
        var playerRigidbody = player.GetComponent<Rigidbody>();
        playerRigidbody.WakeUp();
        snakeController.isPlaying = true;
        playerRigidbody.AddForce(snakeController.direction * snakeController.speedHorizontal);
    }
}
