using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    //Checks
    public bool crashed;

    //drive
    public float carSpeed;
    public float maxSpeed;
    public float drag = .98f;
    public float steerAngle = 20;
    public float traction = 10;
    private Vector3 moveForce;

    //GM
    public GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        crashed = false;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!crashed)
        {
            Drive();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Collision with other cars causes a Game Over State
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("Crashed" + collision.gameObject.name);
            crashed = true;
            gameManager.GameOverScreen();
            gameManager.alive = false;

            FindObjectOfType<AudioManager>().Play("Crash");
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Parking"))
        {
            //Collision with parking space finishes level
            Debug.Log("Parked");
            crashed = true;
            gameManager.alive = false;
            gameManager.ParkedScreen();
        }
    }

    private void Drive()
    {
        //Move Forward
        moveForce += transform.forward * carSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += moveForce * Time.deltaTime;

        //steering
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * moveForce.magnitude * steerAngle * Time.deltaTime);

        //drag and max speed
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);

        //traction
        Debug.DrawRay(transform.position, moveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
    }
}


