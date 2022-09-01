using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    GameSettings gameSettings;
    Button button;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        gameSettings = FindObjectOfType(typeof(GameSettings)) as GameSettings;
        button = GetComponent<Button>();

    }

    void LateUpdate()
    {
        i = 0;

        if (i == 0)
        {
            button.onClick.AddListener(DowlandGameScene);
        }
    }



    void DowlandGameScene()
    {
        if (i == 0)
        {
            if (button.name == "ButtonMenu")
            {
                SceneManager.LoadScene(0);
                i = 0;
            }
            else if (button.name == "ButtonReturn")
            {
                gameSettings.EscapeExitMenu();
                i = 0;
            }
            else
            {
                SceneManager.LoadScene(1);
                i = 0;
            }
        }
        i++;
    }
}
