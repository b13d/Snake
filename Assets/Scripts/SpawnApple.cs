using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{

    public GameObject apple;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        createApple();
    }

    void createApple()
    {
        if (GameObject.FindGameObjectWithTag("Apple"))
        {
            // пропускаю
        }
        else
        {
            Instantiate(apple, new Vector3(Random.Range(-9.30f, 9.30f), Random.Range(-5.60f,4.70f)), Quaternion.Euler(-117,-60,12));
            Debug.Log("Заспавнилось " + i++ + " яблок ");
        }
    }
}
