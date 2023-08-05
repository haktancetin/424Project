using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraScript : MonoBehaviour
{
    private CarControlsMap carControlsMap;
    private Vector3 _mouseMovement;
    public float sensitivity = 0.25f;
    private float xRotation, yRotation;

    public Transform target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        carControlsMap = new CarControlsMap();
        //enabling the Input actions
        carControlsMap.Enable();
    }

    // Update is called once per frame
    void Update()
    {

        // Rotate the camera based on the mouse movement
        _mouseMovement = carControlsMap.PlayerControls.CameraMovement.ReadValue<Vector2>();

        xRotation -= _mouseMovement.y;
        yRotation += _mouseMovement.x;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        //transform.position = target.position + offset;
    }
}
