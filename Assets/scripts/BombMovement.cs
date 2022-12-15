using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    Rigidbody2D bomb;
    [SerializeField] Animator animator;
    [SerializeField] bool hasContacted = false;
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject controller;
    
    // Start is called before the first frame update
    void Start()
    {
        if (animator == null) {
            animator = GetComponent<Animator>();
        }

        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }

        if (bomb == null) {
            bomb = GetComponent<Rigidbody2D>();
        }
        bomb.AddForce(new Vector2(-50000, 10000));
        transform.Rotate(0, 0, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Car") {
            GetComponent<CircleCollider2D>().isTrigger = false;
            // BlowUp();
        }
    }

    void OnCollisionStay2D(Collision2D collider) {
            controller.GetComponent<GameController>().SetReducedLife(1.0f);
            BlowUp();
        }



    void BlowUp() {
        hasContacted = true;
        audio.Play();
        animator.SetInteger("explode", 2);
        GetComponent<CircleCollider2D>().isTrigger = true;
        Invoke("Kill", 2.0f);
    }

     void Kill() {
        Destroy(animator.gameObject);
    }
}
