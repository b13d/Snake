using UnityEngine;

public class CameraConstantWidth : MonoBehaviour
{

    private void Start()
    {
        if(Screen.width > 1080)
        {
            Transform scoreText = GetComponent<Transform>();
            scoreText = scoreText.Find("ScoreText");
            scoreText = scoreText.Find("ScoreText");

        }
    }
}
