using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    int activeButton,y;
    TextMeshProUGUI textColor;
    GameObject textSnake;
    Vector3 scaleChangeUp, scaleChangeDown;
    List<Button> allButton = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        ButtonFirstColor();

        textSnake = GameObject.Find("TextTitle");

        scaleChangeUp = new Vector3(0.001f, 0.001f, 0.001f);
        scaleChangeDown = new Vector3(-0.001f, -0.001f, -0.001f);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.UpArrow)) || Input.GetKey(KeyCode.Return))
        {
            ButtonChangeFocus();
        }

    }

    private void FixedUpdate()
    {
        if (textSnake != null)
        {
            ChangeSizeTitle();
        }

        if (allButton.Count == 0)
        {
            if (GameObject.FindGameObjectsWithTag("Button").Length > 0)
            {
               var countButtonGameObject = GameObject.FindGameObjectsWithTag("Button");

                for (int i = countButtonGameObject.Length; i > 0; i--)
                {
                    allButton.Add(countButtonGameObject[i - 1].GetComponent<Button>());
                }
                ButtonFirstColor();
            }
        }
    }

    void ButtonFirstColor()
    {
        allButton.Clear();

        for (int i = GameObject.FindGameObjectsWithTag("Button").Length; i > 0; i--)
        {
            allButton.Add(GameObject.FindGameObjectsWithTag("Button")[i - 1].GetComponent<Button>());
        }

        allButton.Reverse();


        if (allButton.Count > 0)
        {
            textColor = allButton[0].GetComponentInChildren<TextMeshProUGUI>();
            textColor.color = new Color32(45, 204, 112, 255);
            activeButton = 0;

            for (int i = allButton.Count; i > 1; i--)
            {
                textColor = allButton[i-1].GetComponentInChildren<TextMeshProUGUI>();
                textColor.color = new Color32(255, 204, 0, 255);
            }
        }
    }

    void ButtonChangeFocus()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (activeButton + 1 >= allButton.Count)
            {
                // scip
            }
            else
            {
                textColor = allButton[activeButton].GetComponentInChildren<TextMeshProUGUI>();
                textColor.color = new Color32(255, 204, 0, 255);

                textColor = allButton[activeButton + 1].GetComponentInChildren<TextMeshProUGUI>();
                textColor.color = new Color32(45, 204, 112, 255);
                activeButton = activeButton + 1;

            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (activeButton - 1 < 0)
            {
                // scip
            }
            else
            {
                textColor = allButton[activeButton].GetComponentInChildren<TextMeshProUGUI>();
                textColor.color = new Color32(255, 204, 0, 255);

                textColor = allButton[activeButton - 1].GetComponentInChildren<TextMeshProUGUI>();
                textColor.color = new Color32(45, 204, 112, 255);
                activeButton = activeButton - 1;
            }
        }

        if (Input.GetKey(KeyCode.Return))
        {
            allButton[activeButton].onClick.Invoke();
        }
    }

    void ChangeSizeTitle()
    {
        if (textSnake.transform.localScale.y < 2.4 && y == 0)
        {
            textSnake.transform.localScale += scaleChangeUp;
        }
        else
        {
            y = 1;
        }
        if (textSnake.transform.localScale.y > 2 && y == 1)
        {
            textSnake.transform.localScale += scaleChangeDown;
        }
        else
        {
            y = 0;
        }
    }
}
