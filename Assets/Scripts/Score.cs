using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreMesh;
    public TextMeshProUGUI recordMesh;
/*    public SpriteRenderer appleScore;
    public SpriteRenderer cupScore;*/


    void Awake()
    {
        //appleScore.size = new Vector2(0.5f, 0.5f);

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
        scoreMesh.text = "<sprite=\"Apple\" index=0>" + PlayerPrefs.GetInt("score");
        recordMesh.text = "" + PlayerPrefs.GetInt("record");
    }
}
