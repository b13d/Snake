using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreMesh;
    public TextMeshProUGUI recordMesh;

    void Awake()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", score);
        }
        //textMesh.text = "Score = " + score;
    }

    public void SaveScore()
    {
        score++;

        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.GetInt("record") < score)
        {
            PlayerPrefs.SetInt("record", score);
        }
    }

    private void Update()
    {
        scoreMesh.text = "Score = " + PlayerPrefs.GetInt("score");
        recordMesh.text = "Record = " + PlayerPrefs.GetInt("record");
    }
}
