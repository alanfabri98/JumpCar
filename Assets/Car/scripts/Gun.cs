using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;
    public float fireForce;
    public float fireVelocity;
    private float fireVelocityTime;
    // Start is called before the first frame update
    void Start()
    {
        fireForce = 1500;
        fireVelocity = 0.1f;
        fireVelocityTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > fireVelocityTime)
            {
                GameObject newBullet;
                newBullet = Instantiate(bullet, gun.position, gun.localRotation);
                newBullet.GetComponent<Rigidbody>().AddForce(gun.forward * fireForce);
                fireVelocityTime = Time.time + fireVelocity;
                Destroy(newBullet, 2);
            }
        }
    }
}


