using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Fire", 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}