using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] GameObject controller;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null) {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
         if (animator == null) {
            // animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
