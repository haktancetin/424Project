using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private Camera fpsCamera;

    [SerializeField]
    private Camera leftMirror;

    [SerializeField]
    private Camera centerMirror;

    [SerializeField]
    private Camera rightMirror;

    private Camera currentCamera;

    [SerializeField]
    private float torque = 250f;

    public float score = 0;

    public bool leftBlinkerOn = false;
    public bool rightBlinkerOn = false;

    //Coroutine leftBlinker = null;
    //Coroutine rightBlinker = null;

    Coroutine leftBlinkerFPS = null;
    Coroutine rightBlinkerFPS = null;

    [SerializeField]
    private Image leftBlinkerImage;
    [SerializeField]
    private Image rightBlinkerImage;

    [SerializeField]
    private TextMeshProUGUI TutorialText;

    private float _originalRotX;
    private float _originalRotY;
    private float _originalRotZ;

    private float _originalPosX;
    private float _originalPosY;
    private float _originalPosZ;

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

    private IEnumerator LeftBlinkerFPS()
    {
        while (true)
        {

            leftBlinkerImage.enabled = false;
            yield return new WaitForSeconds(0.3f);
            leftBlinkerImage.enabled = true;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator RightBlinkerFPS()
    {
        while (true)
        {
            rightBlinkerImage.enabled = false;
            yield return new WaitForSeconds(0.3f);
            rightBlinkerImage.enabled = true;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void ActivateLeftMirror()
    {
        currentCamera.enabled = false;
        leftMirror.enabled = true;
    }

    private void ActivateRightMirror()
    {
        currentCamera.enabled = false;
        rightMirror.enabled = true;
    }

    private void ActivateCenterMirror()
    {
        currentCamera.enabled = false;
        centerMirror.enabled = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        carControlsMap = new CarControlsMap();


        carControlsMap.PlayerControls.Reset.performed += context =>
        {
            transform.position = new Vector3(_originalPosX, _originalPosY, _originalPosZ);
            transform.rotation = (Quaternion.Euler(new Vector3(_originalRotX, _originalRotY, _originalRotZ)));
        };

        carControlsMap.PlayerControls.ToggleTutorial.performed += context =>
        {
            TutorialText.enabled = !TutorialText.enabled;
        };


        carControlsMap.PlayerControls.LeftMirror.performed += context =>
        {
            currentCamera.enabled = false;
            rightMirror.enabled = false;
            centerMirror.enabled = false;
            leftMirror.enabled = true;
        };

        carControlsMap.PlayerControls.LeftMirror.canceled += context =>
        {
            leftMirror.enabled = false;
            currentCamera.enabled = true;
        };

        carControlsMap.PlayerControls.RightMirror.performed += context =>
        {
            currentCamera.enabled = false;
            leftMirror.enabled = false;
            centerMirror.enabled = false;
            rightMirror.enabled = true;
            
        };

        carControlsMap.PlayerControls.RightMirror.canceled += context =>
        {
            currentCamera.enabled = true;
            rightMirror.enabled = false;
        };

        carControlsMap.PlayerControls.CenterMirror.performed += context =>
        {
            currentCamera.enabled = false;
            leftMirror.enabled = false;
            rightMirror.enabled = false;
            centerMirror.enabled = true;
        };

        carControlsMap.PlayerControls.CenterMirror.canceled += context =>
        {
            currentCamera.enabled = true;
            centerMirror.enabled = false;
        };

        carControlsMap.PlayerControls.LeftBlinker.performed += context =>
        {
            if (leftBlinkerOn)
            {
                StopCoroutine(leftBlinkerFPS);
                leftBlinkerImage.enabled = false;
                leftBlinkerOn = false;
            }
            else
            {
                leftBlinkerOn = true;
                if (rightBlinkerOn)
                {
                    StopCoroutine(rightBlinkerFPS);
                }
                leftBlinkerFPS = StartCoroutine(LeftBlinkerFPS());
            }
        };

        carControlsMap.PlayerControls.RightBlinker.performed += context =>
        {
            if (rightBlinkerOn)
            {
                StopCoroutine(rightBlinkerFPS);
                rightBlinkerOn = false;
            }
            else
            {
                rightBlinkerOn = true;
                if (leftBlinkerOn)
                {
                    StopCoroutine(leftBlinkerFPS);
                }
                rightBlinkerFPS = StartCoroutine(RightBlinkerFPS());
            }
        };

        carControlsMap.Enable();
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        currentCamera = fpsCamera;
        currentCamera.enabled = true;

        leftBlinkerImage.enabled = false;
        rightBlinkerImage.enabled = false;
        TutorialText.enabled = false;

        _originalRotX = transform.rotation.x;
        _originalRotY = transform.rotation.y;
        _originalRotZ = transform.rotation.z;

        _originalPosX = transform.position.x;
        _originalPosY = transform.position.y;
        _originalPosZ = transform.position.z;
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

    }
}
