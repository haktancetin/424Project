using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CrashCameraRotation : MonoBehaviour
{

    public GameObject car;
    private float rotationSpeed = 3f;
    private bool turnOnCameras;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        turnOnCameras = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CarCrash.isCrashed)
        {
            if (turnOnCameras)
            {
                camera1.gameObject.SetActive(false);
                camera2.gameObject.SetActive(false);
                camera3.gameObject.SetActive(false);
                camera4.gameObject.SetActive(false);
                CarControllerScript control = car.GetComponent<CarControllerScript>();
                control.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                canvas.SetActive(true);
                
                turnOnCameras = false;
            }
            Vector3 destination = car.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(destination, Vector3.up);
            transform.Translate(rotationSpeed * Time.deltaTime,0,0);
        }
   
    }
}
