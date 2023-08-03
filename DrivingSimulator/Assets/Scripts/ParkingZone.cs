using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParkingZone : TutorialZone
{
    [SerializeField] List<GameObject> parkingZonesList = new List<GameObject>();
    public UnityAction OnParkComplete;

    private void OnEnable()
    {
        OnParkComplete += SelectRandomParkingSlot;
        SelectRandomParkingSlot();
    }
    void SelectRandomParkingSlot()
    {
        parkingZonesList[Random.Range(0, parkingZonesList.Count)].gameObject.SetActive(true);
    }
}
