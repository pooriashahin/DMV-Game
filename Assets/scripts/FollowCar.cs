using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Follow;
    private Transform TriggerBox;

    void Start()
    {
        Follow = GameObject.Find("body");
        TriggerBox = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerBox.position = Follow.GetComponent<Transform>().position;
    }
}
