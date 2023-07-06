using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerScript : MonoBehaviour
{
    private CarControlsMap carControlsMap;
    private Rigidbody rigidBody;

    [Range(1,500)]
    public float forceMultiplier;

    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        carControlsMap = new CarControlsMap();
        carControlsMap.Enable();
        rigidBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Movement
        
        float accelerate = carControlsMap.PlayerControls.Accelerate.ReadValue<float>();
        float turn = carControlsMap.PlayerControls.Turn.ReadValue<float>();
        float handbrake = carControlsMap.PlayerControls.Handbrake.ReadValue<float>();

        Debug.Log("acc: " + Vector3.forward * accelerate);
        Debug.Log("turn: " + turn);
        Debug.Log("handbrake: " + handbrake);

        rigidBody.AddRelativeForce(Vector3.forward * forceMultiplier * accelerate);

        transform.RotateAroundLocal(Vector3.up, turn * turnSpeed * Time.deltaTime);
        rigidBody.AddForce(Vector3.right * turn);
        
        rigidBody.AddForce(Vector3.forward * -1 * handbrake);

        //Other Controls

        float blinker = carControlsMap.PlayerControls.Blinkers.ReadValue<float>();
        if(blinker < 0)
        {

        }
        else if(blinker > 0)
        {

        }
    }
}
