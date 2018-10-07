using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour {
    public GameObject bulletPrefab;

    // Use this for initialization
    void Start () {

        // Calls Fire every second
        InvokeRepeating("Fire", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void Fire()
    {
        // Spawns the bullet
        var bullet = (GameObject)Instantiate(
        bulletPrefab,
        transform.position,
        transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 6;

        // Destroys the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
