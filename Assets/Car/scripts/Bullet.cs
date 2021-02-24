using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Barrel"))
        {
            GameManager.instance.PickBarrel();
            Destroy(collision.gameObject, 2);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("coin"))
        {
            GameManager.instance.PickCoin();
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("item"))
        {
            GameManager.instance.PickItem();

            Destroy(collision.gameObject);
        }
    }
}
