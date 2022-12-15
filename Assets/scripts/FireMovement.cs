using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
    [SerializeField] GameObject tire;
    [SerializeField] GameObject car;
    [SerializeField] Rigidbody2D fire;

    // Start is called before the first frame update
    void Start()
    {
        if (tire == null) {
            tire = GameObject.FindGameObjectWithTag("Tire");
        }
        if (car == null) {
            car = GameObject.FindGameObjectWithTag("Car");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Collider2D>().transform.rotation = Quaternion.Euler(0, 0, car.transform.eulerAngles.z - 90);
        transform.position = new Vector3(tire.transform.position.x - 1, tire.transform.position.y, tire.transform.position.z);
    }
}
