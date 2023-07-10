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
    private GameManagerScript gameManagerScript;

    [SerializeField]
    private float maxSteerAngle = 30f;

    [SerializeField]
    private float maxBrakeTorque = 500f;

    [SerializeField]
    private WheelCollider[] wheelColliders;

    [SerializeField]
    private GameObject steeringWheel;

    [SerializeField]
    private Material[] lights;

    [SerializeField]
    private GameObject[] cameras;

    private bool current_camera = false;

    [SerializeField]
    private float torque = 250f;

    [Range(1,500)]
    public float forceMultiplier;

    [Range(1, 500)]
    public float handbrakeDrag;

    public float score = 0;

    private bool leftBlinkerOn = false;
    private bool rightBlinkerOn = false;

    Coroutine leftBlinker = null;
    Coroutine rightBlinker = null;

    private IEnumerator LeftBlinker()
    {
        while (true)
        {
            lights[0].EnableKeyword("_EMISSION");
            lights[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
            yield return new WaitForSeconds(0.3f);
            lights[0].DisableKeyword("_EMISSION");
            lights[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator RightBlinker()
    {
        while (true)
        {
            lights[1].EnableKeyword("_EMISSION");
            lights[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
            yield return new WaitForSeconds(0.3f);
            lights[1].DisableKeyword("_EMISSION");
            lights[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void SwitchCamera(bool current)
    {
        // 0 -> TPS Camera
        // 1 -> FPS Camera
        
        if (current)
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
        }
        else
        {
            cameras[1].SetActive(false);
            cameras[0].SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        carControlsMap = new CarControlsMap();
        carControlsMap.Enable();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        cameras[1].SetActive(false);
        cameras[0].SetActive(true);
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

        /*
        if(turn != 0)
        {
            Vector3 rotation = steeringWheel.transform.localEulerAngles;
            rotation.z += turn * maxSteerAngle;
            transform.localEulerAngles = rotation;
        }
        else
        {

        }
        */
        
        //Other Controls - Blinkers, Horn etc.

        float blinker = carControlsMap.PlayerControls.Blinkers.ReadValue<float>();
        if(blinker < 0)
        {
            if (leftBlinkerOn)
            {
                StopCoroutine(leftBlinker);
                lights[0].DisableKeyword("_EMISSION");
                lights[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                leftBlinkerOn = false;
            }
            else
            {
                leftBlinkerOn = true;
                if (rightBlinkerOn)
                {
                    StopCoroutine(rightBlinker);
                    lights[1].DisableKeyword("_EMISSION");
                    lights[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                }
                leftBlinker = StartCoroutine(LeftBlinker());
            }
        }
        else if(blinker > 0)
        {
            if (rightBlinkerOn)
            {
                StopCoroutine(rightBlinker);
                lights[1].DisableKeyword("_EMISSION");
                lights[1].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                rightBlinkerOn = false;
            }
            else
            {
                rightBlinkerOn = true;
                if (leftBlinkerOn)
                {
                    StopCoroutine(leftBlinker);
                    lights[0].DisableKeyword("_EMISSION");
                    lights[0].globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

                }
                rightBlinker = StartCoroutine(RightBlinker());
            }
        }

        float tutorial = carControlsMap.PlayerControls.ToggleTutorial.ReadValue<float>();
        if(tutorial != 0)
        {
            gameManagerScript.ToggleTutorial();
        }

        float camera = carControlsMap.PlayerControls.CameraSwitch.ReadValue<float>();
        if(camera > 0)
        {
            current_camera = !current_camera;
            SwitchCamera(current_camera);
        }
    }
}
