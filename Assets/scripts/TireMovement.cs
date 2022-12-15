using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TireMovement : MonoBehaviour
{
    [SerializeField] public static Rigidbody2D tire;
    [SerializeField] float horizontalMovement;
    [SerializeField] bool brake = false;
    [SerializeField] float verticalMovement;
    [SerializeField] int initialSpeed = 50;
    [SerializeField] int speed = 25;
    [SerializeField] public int gear = 1;
    [SerializeField] public Text gearNumber;
    // [SerializeField] public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        // tire = GetComponent<Rigidbody2D>();
        //   if (car == null) {
        //     car = GameObject.FindGameObjectWithTag("Car");
        // }
        gear = 1;
        if (gearNumber == null) {
            gearNumber = GetComponent<Text>();
        }
    }

    public void SetTire(Rigidbody2D targetTire) {
        tire = targetTire;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("up")) {
            if (gear < 4) {
                gear++;
                return;
            }
        }

        if (Input.GetKeyDown("down")) {
            if (gear > 1) {
                gear--;
                return;
            }
        }

        if (gearNumber != null && gear != null) {
            gearNumber.text = gear + "";
        }



         if(horizontalMovement != 0) {
            brake = false; 
        }

    }

    void FixedUpdate() {
        tire.AddTorque(speed * -horizontalMovement * Time.fixedDeltaTime);

        if (brake) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            tire.AddTorque(0);
        }
        // tire.velocity = new Vector2(horizontalMovement * speed, 0);

        // float rotation = 0f;
        // if (horizontalMovement > 0)
        //     rotation = horizontalMovement * (-35);
        // if (horizontalMovement < 0)   
        //     rotation = horizontalMovement * (-15);
        // RotateTire(rotation);
    //  if (car.velocity > 10.0f) {
    //         car.velocity = new Vector2(car.velocity.x - 1, car.velocity.y);
    //     }

        if(Input.GetButtonDown("Jump")) {
            brake = true;
        }

        if(horizontalMovement > 0) {
            speed = gear * initialSpeed;
        }

        if(horizontalMovement < 0) {
            speed = gear * initialSpeed / 2;
        }
        
        
    }

    void RotateTire(float rotation) {
        transform.Rotate(0, 0, rotation);
    }


    void Brake() {
        gameObject.transform.Rotate(0, 0, 0);
    }

    public int GetGear() {
        return gear;
    }
}
