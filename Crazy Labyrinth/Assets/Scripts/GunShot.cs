using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    float[] pattern = new float[]{3.0f, 2.0f, 4.0f};
    float shootInterval;
    float timeAc = 0.0f;
    int patternTracker = 0;

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("Fire", 1f, 4f);
        float shootInterval = pattern[patternTracker];
    }

    // Update is called once per frame
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

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 6;

        // Destroys the bullet after 2 seconds
        Destroy(bullet, 2.0f);

        if(patternTracker == 2)
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