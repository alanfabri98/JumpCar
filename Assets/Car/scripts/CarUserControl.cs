using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float footBrake = 0;
            if (Input.GetKey(KeyCode.Z))
            {
                footBrake = 1;
            }

#if !MOBILE_INPUT
            float handbrake = 0f;
            if (Input.GetKey(KeyCode.X))
            {
                handbrake = 1;
            }
            m_Car.Move(h, v, footBrake, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
