using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SnakeController : MonoBehaviour
{

    public const float MOVE_SPEED = 1f;

    private List<Transform> snaketail;
    [SerializeField] Transform snaketail_prefab;

    Vector3 startPosition;
    public float speedHorizontal = 250.0f;
    public float speedVertical = 250.0f;
    public List<Vector3> Points = new List<Vector3>();

    static string symbol;
    Vector3 direction;

    Rigidbody p_rb;

    float horizontal, vertical;


    // Start is called before the first frame update
    void Start()
    {
        snaketail = new List<Transform>(); // все хвосты, включая голову
        snaketail.Add(this.transform);
        startPosition = snaketail[0].position;

        p_rb = GetComponent<Rigidbody>();
    }
    void AddTail() // Добавляем хвост
    {
        Transform tail = Instantiate(this.snaketail_prefab);
        tail.position = snaketail[snaketail.Count - 1].position;

        snaketail.Add(tail);
    }

    void FixedUpdate()
    {
        float dist = Vector3.Distance(startPosition, transform.position);

        if (dist > 1)
        {
            startPosition = transform.position;
            Points.Add(startPosition);
        }
        Debug.Log(Points.Count);

        if (Points.Count > 100)
        {
            Points.RemoveRange(0, 50);
        }
    }

    private void LateUpdate()
    {
        for (int i = snaketail.Count; i > 1; i--)
        {
            snaketail[i - 1].position = Points[Points.Count - i];
        }
    }


    void Update()
    {

        // Здесь нужно перехватить событие, нажатие кнопки, и получить его название

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

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
            //transform.Rotate(new Vector3(0, 0, 180), Space.Self);

            symbol = "S";
            p_rb.constraints = RigidbodyConstraints.FreezePositionX;
            p_rb.AddForce(transform.up * speedVertical);
            direction = transform.up * (-1);
        }

        if (Input.GetKeyDown(KeyCode.D) == true && (symbol != "D" && symbol != "A"))
        {
            
            //transform.rotation = Quaternion.Euler(new Vector3( 0, 0, -90));
            transform.Rotate(new Vector3( 0, 0, -90), Space.Self);


            symbol = "D";
            p_rb.constraints = RigidbodyConstraints.FreezePositionY;
            p_rb.AddForce(transform.up * speedHorizontal);
            direction = transform.right;



        }

        if (Input.GetKeyDown(KeyCode.A) == true && (symbol != "A" && symbol != "D"))
        {
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            transform.Rotate(new Vector3( 0, 0, 90f), Space.World);

            symbol = "A";
            p_rb.constraints = RigidbodyConstraints.FreezePositionY;
            p_rb.AddForce(transform.up * speedHorizontal);
            direction = transform.right * (-1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            Destroy(other.gameObject);
            AddTail();
        }
    }
}
