using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {
    public float speed;
    private Rigidbody _rb;
    private GameObject _currentCheckpoint;
    public GameObject ball;

    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>(); // Gets access Rigidbody
    }
	
	// Update is called once per frame
	void Update () {
        // This code is used so that player input can move the ball
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.AddForce(movement * speed);
    }
    // This code is used to determine collisons 
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint")) // If Ball Hits Checkpoint
        {
            _currentCheckpoint = other.gameObject;

        }
        if (other.gameObject.CompareTag("Bullet") || other.gameObject.CompareTag("Hole")) // If ball hits bullet or hole go back to checkpoint
        {
            transform.position = _currentCheckpoint.transform.position;
        }
            if (other.gameObject.CompareTag("Finish"))// End screen
        {
            SceneManager.LoadScene("ScoreScreen");
        }


    }
    public void backToCheckPoint()
    {
        transform.position = _currentCheckpoint.transform.position;
    }
}
