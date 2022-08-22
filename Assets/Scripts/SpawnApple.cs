using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{

    public GameObject apple;

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
            Instantiate(apple, new Vector3(Random.Range(-14f, 14f), Random.Range(-4.30f,4.30f)), Quaternion.Euler(-117,-60,12));
        }
    }
}
