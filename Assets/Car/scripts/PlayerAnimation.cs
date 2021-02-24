using UnityEngine;
using System;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(Animator))]

public class PlayerAnimation : MonoBehaviour
{


    protected Animator animator;

    public Transform player;


    void Awake()
    {
        animator = player.GetComponent<Animator>();
    }
    
    void Update()
    {
        animator.SetFloat("Steer", transform.root.GetComponent<CarController>().steer);
    }

  

}