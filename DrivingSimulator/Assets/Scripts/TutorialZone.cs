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

    //GameObject FailUI, SuccessUI;
    protected ZoneType zoneType;
    protected TutorialZonesController tutorialZonesController;
    //[SerializeField] protected PrometeoCarController carController;

    protected int wrongAttempts = 0;
    protected int correctAttempts = 0;

    private void Awake()
    {
        tutorialZonesController = GameObject.Find("TutorialZonesController").GetComponent<TutorialZonesController>();
    }

}
