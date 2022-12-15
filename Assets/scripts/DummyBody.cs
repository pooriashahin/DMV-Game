using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBody : MonoBehaviour
{
    [SerializeField] GameObject dummy;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bomb;
    [SerializeField] bool isAngry = false;
    [SerializeField] bool isAngryOnce = false;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        x = 0.5f;
        y = 0.35f;
        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }

    }

  void OnTriggerEnter2D(Collider2D collider) {

         if (collider.gameObject.tag == "Car" && !isAngry && dummy != null) {
            dummy.GetComponent<Animator>().SetInteger("explode", 1);
            dummy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.75f);
        }
    }

     void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.tag == "Car" && collider.gameObject.GetComponent<CarMovement>().GetIfIsHunking() && !isAngry && !isAngryOnce && dummy != null) {
            isAngry = true;
            isAngryOnce = true;
            dummy.GetComponent<Animator>().SetInteger("explode", 3);
            dummy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Invoke("Groan", 1.5f);
            Invoke("StartThrowing", 3.0f);
            Invoke("StopBeingAngry", 20.0f);
        }
     }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void Groan() {
        if (dummy != null)
            audio.Play();
    }

    void StopBeingAngry() {
        isAngry = false;
        if (dummy != null) {
            dummy.GetComponent<Animator>().SetInteger("explode", 5);
        }
    }

    void StartThrowing() {
        InvokeRepeating("CreateBomb", 0.25f, 0.6f);
        dummy.GetComponent<Animator>().SetInteger("explode", 4);
    }

    void CreateBomb() {
        if (dummy != null && isAngry) {
            Vector2 position = new Vector2(dummy.GetComponent<Rigidbody2D>().position.x - x, dummy.GetComponent<Rigidbody2D>().position.y + y);
            Instantiate(bomb, position, Quaternion.identity);
        }
        
    }


}
