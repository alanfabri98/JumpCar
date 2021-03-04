using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peaks : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            GameManager.instance.loseLife();
        }
    }
}
