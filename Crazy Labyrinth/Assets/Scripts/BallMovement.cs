using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    public GameObject currentcheckpoint;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>(); //Gets access Rigidbody
    }
	
	// Update is called once per frame
	void Update () {
        //This code is used so that player input can move the ball
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint 1"))
        {
            currentcheckpoint = other.gameObject;

        }
        else if(other.gameObject.CompareTag("Checkpoint 2"))
        {
            currentcheckpoint = other.gameObject;
        }
        //This code is for when bullets hit the sphere
    }
}
