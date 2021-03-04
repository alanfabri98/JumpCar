using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            GameManager.instance.PickBarrel();
            Destroy(this.gameObject, 2);
        }
    }
   
   
}
