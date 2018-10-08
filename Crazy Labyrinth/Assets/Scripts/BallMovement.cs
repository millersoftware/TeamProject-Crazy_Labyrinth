using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private GameObject currentcheckpoint;
    public GameObject ball;

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
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            currentcheckpoint = other.gameObject;

        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            transform.position = currentcheckpoint.transform.position;
        }
            if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("ScoreScreen");
        }


    }
    public void backToCheckPoint()
    {
        transform.position = currentcheckpoint.transform.position;
    }
}
