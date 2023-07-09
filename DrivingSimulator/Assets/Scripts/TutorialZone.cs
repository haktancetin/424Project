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

    [SerializeField] GameObject FailUI, SuccessUI;
    protected ZoneType zoneType;
    protected int Health;
    protected TutorialZonesController tutorialZonesController;
    [SerializeField] protected PrometeoCarController carController;
    private void Start()
    {
       
        SetStartConditions();
        success();
    }

    protected virtual void SetStartConditions()
    {
        tutorialZonesController = GameObject.Find("TutorialZonesController").GetComponent<TutorialZonesController>();
    }

    void success()
    {
        tutorialZonesController.Deneme();
    }
    
}
