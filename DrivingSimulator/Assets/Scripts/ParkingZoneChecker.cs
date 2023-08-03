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
    private void OnCollisionEnter(Collision collision)
    {
            parkingSlotScript.Counter++;
            Debug.Log($"{gameObject.name} collider entered");
        if(collision.collider.CompareTag("Player"))
        {
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            parkingSlotScript.Counter--;
            Debug.Log($"{gameObject.name} collider left");
        }
    }
}
