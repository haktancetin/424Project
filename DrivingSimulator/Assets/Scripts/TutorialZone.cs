using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialZone : MonoBehaviour
{
   public enum ZoneType
    {
        TrafficLightsZone,
        ParkingZone

    }

    protected ZoneType zoneType;
    protected TutorialZonesController tutorialZonesController;
    //[SerializeField] protected PrometeoCarController carController;

    private void Awake()
    {
        tutorialZonesController = GameObject.Find("TutorialZonesController").GetComponent<TutorialZonesController>();
    }

}
