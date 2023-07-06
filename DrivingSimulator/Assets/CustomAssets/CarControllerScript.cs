using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

ICONS LINKS TEMP STORAGE: <a href="https://www.flaticon.com/free-icons/pedal" title="pedal icons">Pedal icons created by Vitaly Gorbachev - Flaticon</a> 
 
*/

public class CarControllerScript : MonoBehaviour
{
    private CarControlsMap carControlsMap;
    private Rigidbody rigidBody;

    [Range(1,500)]
    public float forceMultiplier;

    public float turnSpeed;

    public float maxVel;

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

        //Debug.Log("acc: " + Vector3.forward * accelerate);
        //Debug.Log("turn: " + turn);
        //Debug.Log("handbrake: " + handbrake);

        if(handbrake <= 0)
        {
            rigidBody.AddRelativeForce(Vector3.forward * forceMultiplier * accelerate);
        }

        GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, maxVel);


        //Turning - only turn when accelerating in some way
        //TODO: Check for actual movement, not key press
        transform.RotateAroundLocal(Vector3.up, turn * turnSpeed * accelerate * Time.deltaTime);
        rigidBody.AddRelativeForce(Vector3.right * turn * accelerate);
        
        //Handbrake - Slower than foot brake
        if(rigidBody.velocity.magnitude > 0 )
        {
            rigidBody.AddRelativeForce(-rigidBody.velocity * handbrake * forceMultiplier / 5);
        }
        

        //Other Controls - Blinkers, Horn etc.

        float blinker = carControlsMap.PlayerControls.Blinkers.ReadValue<float>();
        if(blinker < 0)
        {

        }
        else if(blinker > 0)
        {

        }
    }
}
