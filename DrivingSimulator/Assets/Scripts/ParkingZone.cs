using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParkingZone : TutorialZone
{
    [SerializeField] List<GameObject> parkingZonesList = new List<GameObject>();
    public UnityAction OnParkComplete;

    int lastIndex = 0;

    private void OnEnable()
    {
        OnParkComplete += SelectRandomParkingSlot;
        SelectRandomParkingSlot();
    }
    void SelectRandomParkingSlot()
    {
        parkingZonesList[lastIndex].SetActive(false);
        int tempIndex = lastIndex;
        lastIndex = Random.Range(0, parkingZonesList.Count);
        while(lastIndex == tempIndex) 
        {
            lastIndex = Random.Range(0, parkingZonesList.Count);
        }
        parkingZonesList[lastIndex].gameObject.SetActive(true);
        StatTracker.parkingCompleted++;
    }
}
