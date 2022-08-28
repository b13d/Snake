using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    void Awake()
    {
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
}
