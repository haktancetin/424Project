using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerScript : MonoBehaviour
{
    CarControlsMap carControlsMap;

    // Start is called before the first frame update
    void Start()
    {
        carControlsMap = new CarControlsMap();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = carControlsMap.PlayerControls.Movement.ReadValue<Vector3>();

    }
}
