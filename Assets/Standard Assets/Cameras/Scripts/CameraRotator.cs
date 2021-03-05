using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    // Start is called before the first frame update
    private float yaw = 0f;
    private float pitch = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += 10f * Input.GetAxis("Mouse X");
         pitch -= 10f * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
