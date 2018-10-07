using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This code is used to detect bullet hits to our sphere without having to touch the orginal spehere. 
 * The reasons this is used is because our bullets go above the wall and our playerball is smaller then the wall size. 
 */
public class DetectorScript : MonoBehaviour
{
    public GameObject ball;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, .5f, ball.transform.position.z); //Follows PlayerBall

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            BallMovement b = new BallMovement();
                b.backToCheckPoint();
        }
    }
}
