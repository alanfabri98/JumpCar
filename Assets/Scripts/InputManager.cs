using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    static public float throttle;
    static public float brake;
    static public bool turbo = false;
    // public Joystick joystick;
    static public float steer;

    // Update is called once per frame
    void Update()
    {
        throttle = Input.GetAxis("Vertical");
        
        steer = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("space"))
        {
            brake = 1f;
        }
        else
        {
            brake = 0f;
        }
       

        //if(btTurbo.value > 0){
        //    turbo = true;
        //}else{
        //    turbo = false;
        //}
        
    }
}
