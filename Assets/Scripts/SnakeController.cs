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

    public int value = 5;
    public float distanse = 1;

    Vector3 startPosition;
    public float speedHorizontal = 250.0f;
    public float speedVertical = 250.0f;
    public List<Vector3> points = new List<Vector3>();
    public List<Quaternion> rotationTail = new List<Quaternion>();


    static string symbol;
    Vector3 direction; // mb delete?

    Rigidbody p_rb;

    // Start is called before the first frame update
    void Start()
    {
        snaketail = new List<Transform>(); // all tails, including the head
        snaketail.Add(this.transform);
        startPosition = snaketail[0].position;

        p_rb = GetComponent<Rigidbody>();
    }
    public void AddTail() // Add tail
    {
        if (isPlaying == true)
        {
            Transform tail = Instantiate(this.snaketail_prefab);

            if (startPosition == snaketail[0].position)
            {
                tail.position = snaketail[snaketail.Count - 1].position + new Vector3(2.5f,0);
            }
            tail.position = snaketail[snaketail.Count - 1].position + (direction * 6);

            snaketail.Add(tail);
        }
    }

    void FixedUpdate()
    {
        if (isPlaying == true)
        {
            float dist = Vector3.Distance(startPosition, transform.position);

            if (dist > 0.1) // I put a point (wayPoint, at a certain distance)
            {
                startPosition = transform.position;
                points.Add(startPosition);
                rotationTail.Add(transform.rotation);
            }
            //Debug.Log(points.Count);

            if (points.Count > 300) // > 100
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
                // The process of adding a tail and turning it
                if (i == 1)
                {
                    Vector3 positionTail = points[points.Count - (i * value + 3)]; // i + 1

                    snaketail[i].position = Vector3.Lerp(points[points.Count - (i * 3)], positionTail, distanse); // i + 2
                    snaketail[i].rotation = rotationTail[rotationTail.Count - (i + 1)];
                    //Debug.Log("First = "+positionTail);

                }
                else
                {
                    Vector3 positionTail = points[points.Count - (i * value + 3)]; // i + 1

                    snaketail[i].position = Vector3.Lerp(snaketail[i - 1].position, positionTail, distanse); // i + 2
                    snaketail[i].rotation = rotationTail[rotationTail.Count - (i + 1)];
                    //Debug.Log("Second = "+positionTail);
                }

                /*                snaketail[i].position = Vector3.MoveTowards(points[points.Count - (i * 3)], positionTail, 400); // i + 2
                                snaketail[i].rotation = rotationTail[rotationTail.Count - (i + 1)];*/
                var boxColliderFirstTail = snaketail[1].GetComponent<BoxCollider>();
                boxColliderFirstTail.enabled = false;
            }
        }

        //Debug.Log(direction);
    }


    void Update()
    {

        // Here you need to intercept the event, click the button, and get its nameе
        if (isPlaying == true)
        {
            if (Input.GetKeyDown(KeyCode.W) == true && (symbol != "W" && symbol != "S"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //transform.Rotate(new Vector3(0, 0, 0), Space.Self);


                symbol = "W";
                p_rb.constraints = RigidbodyConstraints.FreezePositionX;
                p_rb.AddForce(transform.up * speedVertical);
                direction = new Vector3(0, 1, 0);
            }

            if (Input.GetKeyDown(KeyCode.S) == true && (symbol != "S" && symbol != "W"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

                symbol = "S";
                p_rb.constraints = RigidbodyConstraints.FreezePositionX;
                p_rb.AddForce(transform.up * speedVertical);
                direction = new Vector3(0, -1, 0);
            }

            if (Input.GetKeyDown(KeyCode.D) == true && (symbol != "D" && symbol != "A"))
            {

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                //transform.Rotate(new Vector3( 0, 0, -90), Space.Self);


                symbol = "D";
                p_rb.constraints = RigidbodyConstraints.FreezePositionY;
                p_rb.AddForce(transform.up * speedHorizontal);
                direction = new Vector3(1, 0, 0);



            }

            if (Input.GetKeyDown(KeyCode.A) == true && (symbol != "A" && symbol != "D"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                //transform.Rotate(new Vector3( 0, 0, 90f), Space.World);

                symbol = "A";
                p_rb.constraints = RigidbodyConstraints.FreezePositionY;
                p_rb.AddForce(transform.up * speedHorizontal);
                direction = new Vector3(-1, 0, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTail" || other.gameObject.tag == "Block")
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
