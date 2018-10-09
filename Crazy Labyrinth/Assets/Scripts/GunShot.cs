using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    float[] pattern = new float[] { 1.0f, 1.0f, 1.0f, 4.0f, 1.0f, 1.0f, 1.0f, 6.0f }; // Change these numbers to change shooting pattern
    float shootInterval; // Current delay time
    float timeAc = 0.0f; // Time past since last shot
    int patternTracker = 0; // Current delay being used
    public Material coating; // Red material

    // Use this for initialization
    void Start()
    {
        // int randStart = Random.Range(0, 7); Uncomment this to have each gun start at a random place in the pattern
        //patternTracker = randStart;
        float shootInterval = pattern[patternTracker];
    }

    // Update checks to see if it is time to shoot then calls fire when ready
    void Update()
    {
        if (Time.deltaTime + timeAc > shootInterval)
        {
            timeAc = 0.0f;
            Fire();
        }

        else
            timeAc += Time.deltaTime;
    }

    void Fire()
    {
        Debug.Log("BANG!");
        // Spawns the bullet
        var bullet = (GameObject)Instantiate(
        bulletPrefab,
        transform.position,
        transform.rotation);
        bulletPrefab.tag = "Bullet";
        bulletPrefab.GetComponent<MeshRenderer>().material = coating;

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 6;

        // Destroys the bullet after 2 seconds
        Destroy(bullet, 2.0f);

        // This loops the pattern array
        if (patternTracker == 7)
        {
            patternTracker = 0;
            shootInterval = pattern[patternTracker];
        }
        else
        {
            patternTracker += 1;
            shootInterval = pattern[patternTracker];
        }
    }
}