using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingZoneChecker : MonoBehaviour
{
    ParkingSlot parkingSlotScript;

    private void Start()
    {
        parkingSlotScript = GetComponentInParent<ParkingSlot>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parkingSlotScript.Counter++;
            Debug.Log($"{gameObject.name} collider entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parkingSlotScript.Counter--;
            Debug.Log($"{gameObject.name} collider left");
        }
    }
}
