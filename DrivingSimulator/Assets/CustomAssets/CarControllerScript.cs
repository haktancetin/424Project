using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

ICONS LINKS TEMP STORAGE: <a href="https://www.flaticon.com/free-icons/pedal" title="pedal icons">Pedal icons created by Vitaly Gorbachev - Flaticon</a> 
 
*/

public class CarControllerScript : MonoBehaviour
{
    private CarControlsMap carControlsMap;

    [SerializeField]
    private float maxSteerAngle = 30f;

    [SerializeField]
    private float maxBrakeTorque = 500f;

    [SerializeField]
    private WheelCollider[] wheelColliders;


    [SerializeField]
    private float torque = 250f;

    [Range(1,500)]
    public float forceMultiplier;

    [Range(1, 500)]
    public float handbrakeDrag;

    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        carControlsMap = new CarControlsMap();
        carControlsMap.Enable();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    Vector3 position;
    Quaternion quaternion;

    // Update is called once per frame
    void Update()
    {
        
        //Movement
        
        float accelerate = carControlsMap.PlayerControls.Accelerate.ReadValue<float>();
        float turn = carControlsMap.PlayerControls.Turn.ReadValue<float>();
        float handbrake = carControlsMap.PlayerControls.Handbrake.ReadValue<float>();
        for (int i = 0; i< wheelColliders.Length; i++)
        {
            wheelColliders[i].motorTorque = accelerate * torque;

            if(i < 2)
            {
                wheelColliders[i].steerAngle = turn * maxSteerAngle;
            }
            else
            {
                wheelColliders[i].brakeTorque = handbrake * maxBrakeTorque;
            }

            wheelColliders[i].GetWorldPose(out position, out quaternion);
            wheelColliders[i].transform.GetChild(0).transform.position = position;
            wheelColliders[i].transform.GetChild(0).transform.rotation = quaternion;

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
