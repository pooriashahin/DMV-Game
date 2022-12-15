using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyMovement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D carBody;
    // [SerializeField] float horizontalMovement = 0;
    // [SerializeField] float verticalMovement = 0;
    // [SerializeField] int speed = 10;
    [SerializeField] public float velocity;
    [SerializeField] int initialSpeed = 4;
    // [SerializeField] int gear;
    // [SerializeField] int rotationFactor = 5;
    // [SerializeField] float jumpForce = 1000.0f;
    // [SerializeField] bool isFacingRight = true;
    // [SerializeField] bool jumpPressed = false;
    // [SerializeField] bool isGrounded = true;
    [SerializeField] public Text speedNumber;
    // [SerializeField] bool brake = false;
    // [SerializeField] GameObject tire;
    [SerializeField] GameObject body;
    // [SerializeField] AudioSource screechAudio;
    // Start is called before the first frame update
    void Start()
    {
        if (carBody == null) {
            carBody = GameObject.FindGameObjectWithTag("Car").GetComponent<Rigidbody2D>();
        }

        // if (GetComponent<AudioSource>() == null) {
        //     screechAudio = GetComponent<AudioSource>();
        // }

    //     tire = GameObject.FindGameObjectWithTag("Tire");
 
    //     rotationFactor = 5;
    //    initialSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalMovement = Input.GetAxis("Horizontal");
        // verticalMovement = Input.GetAxis("Vertical");

        // if(horizontalMovement != 0) {
        //     brake = false; 
        // }
        velocity = carBody.velocity.x;
        // body.GetComponent<Rigidbody2D>().velocity = new Vector2(carBody.velocity.x, carBody.velocity.y);
        // speedNumber.text = Mathf.RoundToInt((velocity * 10)) + "";
        // if (velocity < 0) {
        //    speedNumber.text = Mathf.RoundToInt((-1 * velocity * 10)) + ""; 
        // }
         
        // gear = tire.GetComponent<TireMovement>().gear;

        // if (car.velocity.x > gear * 2.525f && gear < 4) {
        //     car.velocity = new Vector2(car.velocity.x - 0.1f, car.velocity.y);
        // }

        // if (car.velocity.x > 15.0f && gear == 4) {
        //     car.velocity = new Vector2(car.velocity.x - 0.1f, car.velocity.y);
        // }
    }


    void Jet() {
    }

    void Jump() {
        // car.AddForce(new Vector2(0, jumpForce));
    }

    void FixedUpdate()
    {
        // if(Input.GetKey(KeyCode.Space)) {
        //     brake = true;
        // }

        // // limits the rotation in z axes
        // Vector3 euler = transform.eulerAngles;
        // if (euler.z > 180) euler.z = euler.z - 360;
        // euler.z = Mathf.Clamp(euler.z, -25, 25);
        // transform.eulerAngles = euler;

        // if (brake && (car.velocity.x >= 0.1f || car.velocity.x <= 0.0f)) {
        //     car.velocity = new Vector2(car.velocity.x/1.1f, car.velocity.y);
        //     AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
        // }

        // if (Input.GetButtonDown("Fire1")) {
        //     car.AddForce(new Vector2(2000, 0));
        // }

    }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.tag == "Ground") {
    //         isGrounded = true;
    //     }
    // }
}
