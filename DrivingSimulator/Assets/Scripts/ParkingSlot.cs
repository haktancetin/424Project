using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSlot : MonoBehaviour
{
    ParkingZone parkingZoneScript;

    [HideInInspector]
    public int Counter;

    [SerializeField] List<GameObject> parkingZoneCheckers = new List<GameObject>();

    private void Start()
    {
        parkingZoneScript = GetComponentInParent<ParkingZone>();
    }

    private void Awake()
    {
            
    }

    private void Update()
    {
        if(Counter == 4)
            parkingZoneScript.OnParkComplete();
    }

}
