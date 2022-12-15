using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D car;
    [SerializeField] float horizontalMovement = 0;
    [SerializeField] float verticalMovement = 0;
    [SerializeField] int speed = 10;
    [SerializeField] public float velocity;
    [SerializeField] int initialSpeed = 4;
    [SerializeField] int gear;
    [SerializeField] int rotationFactor = 5;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;
    [SerializeField] public Text speedNumber;
    [SerializeField] bool brake = false;
    [SerializeField] bool isDead = false;
    [SerializeField] bool isHunking = false;
    [SerializeField] GameObject tire;
    [SerializeField] GameObject body;
    [SerializeField] AudioSource[] audio;
    [SerializeField] GameObject controller;
    
    // Start is called before the first frame update
    void Start()
    {
        if (car == null) {
            car = GetComponent<Rigidbody2D>();
        }

        if (audio == null) {
            audio = GetComponents<AudioSource>();
        }

        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        tire = GameObject.FindGameObjectWithTag("Tire");
 
        rotationFactor = 5;
        initialSpeed = 4;
    }

    public void SetTire(GameObject targetTire) {
        tire = targetTire;
    }

    public void SetBody(Rigidbody2D targetBody) {
        car = targetBody;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if(horizontalMovement != 0) {
            brake = false; 
        }
        velocity = car.velocity.x;
        body.GetComponent<Rigidbody2D>().velocity = new Vector2(car.velocity.x, car.velocity.y);
        speedNumber.text = Mathf.RoundToInt((velocity * 10)) + "";
        if (velocity < 0) {
           speedNumber.text = Mathf.RoundToInt((-1 * velocity * 10)) + ""; 
        }
         
        gear = tire.GetComponent<TireMovement>().gear;

        if (car.velocity.x > gear * 2.525f && gear < 4) {
            car.velocity = new Vector2(car.velocity.x - 0.1f, car.velocity.y);
        }

        if (car.velocity.x > 15.0f && gear == 4) {
            car.velocity = new Vector2(car.velocity.x - 0.1f, car.velocity.y);
        }

    }

    void FixedUpdate()
    {
        if (car.velocity.x > 22.5f) {
            car.velocity = new Vector2(22.5f, car.velocity.y);
        }

        if(Input.GetKey(KeyCode.Space)) {
            brake = true;
        }

        // limits the rotation in z axes
        Vector3 euler = transform.eulerAngles;
        if (euler.z > 180) euler.z = euler.z - 360;
        euler.z = Mathf.Clamp(euler.z, -25, 25);
        transform.eulerAngles = euler;

        if (brake && (car.velocity.x >= 0.1f || car.velocity.x <= 0.0f)) {
            car.velocity = new Vector2(car.velocity.x/1.1f, car.velocity.y);
            // AudioSource.PlayClipAtPoint(GetComponents<AudioSource>()[0].clip, transform.position);
            GetComponents<AudioSource>()[0].Play();
        }

        if (Input.GetKeyDown("left ctrl")) {
            Accelerate();
        }

        if (Input.GetKeyDown("h")) {
            Hunk();
        }
        
        if (controller.GetComponent<GameController>().GetLifeStatus() == false) {
            car.velocity = new Vector2(0, car.velocity.y);
        }
    }

    void Accelerate() {
        car.AddForce(new Vector2(7000, 0));
        // AudioSource.PlayClipAtPoint(GetComponents<AudioSource>()[1].clip, transform.position);
        GetComponents<AudioSource>()[1].Play();
    }

    void Hunk() {
        // AudioSource.PlayClipAtPoint(GetComponents<AudioSource>()[1].clip, transform.position);
        GetComponents<AudioSource>()[3].Play();
        isHunking = true;

        Invoke("StopHunking", 2.0f);
    }

    void StopHunking() {
        isHunking = false;
    }

    public bool GetIfIsHunking() {
        return isHunking;
    }

    // void OnCollisionEnter2D(Collision2D collision) {
    //     if (collision.gameObject.tag == "Ground") {
    //         isGrounded = true;
    //     }
    // }
}
