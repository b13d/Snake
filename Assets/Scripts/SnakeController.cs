using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using TMPro;

public class SnakeController : MonoBehaviour
{
    bool isPlaying = true;

    private List<Transform> snaketail;
    [SerializeField] Transform snaketail_prefab;
    [SerializeField] Score score;
    


    Vector3 startPosition;
    public float speedHorizontal = 250.0f;
    public float speedVertical = 250.0f;
    public List<Vector3> points = new List<Vector3>();
    public List<Quaternion> rotationTail = new List<Quaternion>();


    static string symbol;
    Vector3 direction;

    Rigidbody p_rb;

    // Start is called before the first frame update
    void Start()
    {
        snaketail = new List<Transform>(); // все хвосты, включая голову
        snaketail.Add(this.transform);
        startPosition = snaketail[0].position;

        p_rb = GetComponent<Rigidbody>();
    }
    public void AddTail() // Добавляем хвост
    {
        if (isPlaying == true)
        {
            Transform tail = Instantiate(this.snaketail_prefab);
            tail.position = snaketail[snaketail.Count - 1].position;

            snaketail.Add(tail);
        }
    }

    void FixedUpdate()
    {
        if (isPlaying == true)
        {
            float dist = Vector3.Distance(startPosition, transform.position);

            if (dist > 1) // Ставлю точку(wayPoint, на определенном расстоянии)
            {
                startPosition = transform.position;
                points.Add(startPosition);
                rotationTail.Add(transform.rotation);
            }
            Debug.Log(points.Count);

            if (points.Count > 100)
            {
                points.RemoveRange(0, 50);
            }

        }
    }

    private void LateUpdate()
    {
        if (isPlaying == true)
        {

            for (int i = 1; i < snaketail.Count; i++)
            {
                // Процесс добавления хвоста и его поворот
                Vector3 positionTail = points[points.Count - ( i + 1 )]; 
                snaketail[i].position = Vector3.MoveTowards(points[points.Count - (i + 2)], positionTail, 400);
                snaketail[i].rotation = rotationTail[rotationTail.Count - (i + 1)];

            }

        }
    }


    void Update()
    {

        // Здесь нужно перехватить событие, нажатие кнопки, и получить его название
        if (isPlaying == true)
        {
            if (Input.GetKeyDown(KeyCode.W) == true && (symbol != "W" && symbol != "S"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //transform.Rotate(new Vector3(0, 0, 0), Space.Self);


                symbol = "W";
                p_rb.constraints = RigidbodyConstraints.FreezePositionX;
                p_rb.AddForce(transform.up * speedVertical);
                direction = transform.up;
            }

            if (Input.GetKeyDown(KeyCode.S) == true && (symbol != "S" && symbol != "W"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

                symbol = "S";
                p_rb.constraints = RigidbodyConstraints.FreezePositionX;
                p_rb.AddForce(transform.up * speedVertical);
                direction = transform.up;
            }

            if (Input.GetKeyDown(KeyCode.D) == true && (symbol != "D" && symbol != "A"))
            {

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                //transform.Rotate(new Vector3( 0, 0, -90), Space.Self);


                symbol = "D";
                p_rb.constraints = RigidbodyConstraints.FreezePositionY;
                p_rb.AddForce(transform.up * speedHorizontal);
                direction = transform.up;



            }

            if (Input.GetKeyDown(KeyCode.A) == true && (symbol != "A" && symbol != "D"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                //transform.Rotate(new Vector3( 0, 0, 90f), Space.World);

                symbol = "A";
                p_rb.constraints = RigidbodyConstraints.FreezePositionY;
                p_rb.AddForce(transform.up * speedHorizontal);
                direction = transform.up;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Block")
        {
            isPlaying = false;
            p_rb.Sleep();

            GameObject message = GameObject.Find("CanvasMessage");
            var parent = message.transform;

            parent = parent.Find("MenuMessage");
            var FinalScore = parent.Find("FinalScore");

            var FinalText = FinalScore.gameObject.GetComponent<TextMeshProUGUI>();
            
            var parentGameObject = parent.gameObject;

            // вызов метода, для смены данных на табло
            ScoreEnd(FinalText);

            parentGameObject.SetActive(true);
            
        }
    }

    void ScoreEnd(TextMeshProUGUI FinalText)
    {
        var scorePlayer = PlayerPrefs.GetInt("score");
        var recordPlayer = PlayerPrefs.GetInt("record");

        if (scorePlayer == recordPlayer)
        {
            FinalText.text = "NEW RECORD\n " + recordPlayer;
        }
        else
            FinalText.text = "SCORE\n " + scorePlayer;
    }



}
