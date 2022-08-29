using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameSettings : MonoBehaviour
{
    void Awake()
    {
        CameraSettings();
        StartingValues();
    }

    void StartingValues()
    {
        GameObject message = GameObject.Find("CanvasMessage");
        var parent = message.transform;
        parent = parent.Find("MenuMessage");

        var parentGameObject = parent.gameObject;
        if (parentGameObject.active == true)
            parentGameObject.SetActive(false);
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
            recordText.fontSize = 45;
            scoreText.fontSize = 45;
        }
    }

    private void Update()
    {
        var score = GameObject.Find("ScoreText");
        var scoreText = score.GetComponent<TextMeshProUGUI>();
        var record = GameObject.Find("RecordText");
        var recordText = record.GetComponent<TextMeshProUGUI>();
        if (Screen.width > 1280)
        {
            recordText.fontSize = 60;
            scoreText.fontSize = 60;
        }
        else
        {
            recordText.fontSize = 25;
            scoreText.fontSize = 25;
        }
    }
}
