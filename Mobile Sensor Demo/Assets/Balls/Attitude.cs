using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Android;
using Gyroscope = UnityEngine.Gyroscope;



public class Attitude : MonoBehaviour
{
    private Gyroscope gyro;
    private bool gyroSupported;


    void Start()
    {
        gyroSupported = SystemInfo.supportsGyroscope;

        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            Debug.Log("Gyroscope is supported and enabled.");
        }
        else
        {
            Debug.Log("Gyroscope not supported on this device.");
        }
    }

    void Update()
    {
        // Get device rotation as quaternion
        Quaternion deviceRotation = gyro.attitude;

        // Convert to Unity coordinate space (Android/iOS native to Unity)
        Quaternion adjustedRotation = new Quaternion(-deviceRotation.x, -deviceRotation.y, deviceRotation.z, deviceRotation.w);

        // Get angles
        Vector3 eulerAngles = adjustedRotation.eulerAngles;

        float rotateX = eulerAngles.x;
        float rotateY = eulerAngles.y;
        float rotateZ = eulerAngles.z;
        gameObject.transform.rotation = Quaternion.Euler(rotateX, 45, rotateY); 
        
    }
}

