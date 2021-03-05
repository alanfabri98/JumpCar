using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject explosion;
    
    private void OnCollisionEnter(Collision collision)
    {
  
        GameObject obj = Instantiate(explosion, transform.position, transform.rotation);
        GameManager.instance.loseLifeLaser();
        Destroy(obj, 1);
        Destroy(gameObject);
    }
}
