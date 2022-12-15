using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMovement : MonoBehaviour
{
    Rigidbody2D dummy;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audio;
    [SerializeField] bool hasContacted = false;
    [SerializeField] bool isNotified = false;
    [SerializeField] GameObject controller;
    [SerializeField] GameObject notificationObj;
    [SerializeField] bool isNotificationOn;
    // Start is called before the first frame update
    void Start()
    {
        if (dummy == null) {
            dummy = GetComponent<Rigidbody2D>();
        }
        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

        if (notificationObj == null) {
            notificationObj = GameObject.FindGameObjectWithTag("HitAndRun");
        }

        if (animator == null) {
            animator = GetComponent<Animator>();
        }

        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider) {
    
        if (collider.gameObject.tag == "Car") {
            hasContacted = true;
            audio.Play();
            BlowUp();
        }

        if (collider.gameObject.tag == "Car" && gameObject.tag == "Dummy") {
            controller.GetComponent<GameController>().SetReducedLife(35.0f);
            if (controller.GetComponent<GameController>().GetLifeStatus() && !isNotified) {
                isNotificationOn = PersistentData.Instance.GetNotificationsOption();
                if (isNotificationOn) {
                    notificationObj.SetActive(true);
                    Invoke("KillNotification", 15.0f);
                }
            }
        }
     }

    void BlowUp() {
        animator.SetInteger("explode", 2);
        Invoke("Kill", 1.0f);
    }

    void Kill() {
        Destroy(animator.gameObject);
    }

    void KillNotification() {
        notificationObj.SetActive(false);
        isNotified = true;
    }
}
