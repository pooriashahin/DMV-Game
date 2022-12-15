using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    // public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    // Start is called before the first frame update
    void Start()
    {
        // if (target == null) {
        //     target = GameObject.FindGameObjectWithTag("Car").transform;
        // }
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SetTarget(Transform car) {
        target = car;
    }

    
    void FixedUpdate() {
        // Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10.0f);
        // for horizontal follow only add this instead.
        Vector3 targetPosition = new Vector3(target.position.x + 6, transform.position.y, -10.0f);
        if (target.position.x > 1608) {
            targetPosition = new Vector3(target.position.x + (1614 - target.position.x), transform.position.y, -10.0f);
        }
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }

}
