using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Car") {
            Destroy(gameObject);
            controller.GetComponent<GameController>().RefillLife();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
