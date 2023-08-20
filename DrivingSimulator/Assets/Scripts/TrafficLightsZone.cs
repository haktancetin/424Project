using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsZone : TutorialZone
{
    private int requiredCorrectAttempts = 4;
    UIManager manager;

    private void Start()
    {
        manager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
    }

    public void CheckFailSuccess(TrafficLightController.Lightcolor light)
    {

        //float carSpeed = carController.carSpeed;

        if (light == TrafficLightController.Lightcolor.red)
        {
            StatTracker.redlightPassed++;
            manager.UpdateUI();

            if (StatTracker.redlightPassed >= 2)
            {
                StatTracker.redlightPassed = 0;
                StatTracker.greenlightPassed = 0;
                manager.UpdateUI();
                tutorialZonesController.RestartTutorial();
            }
        }
        else
        {
            StatTracker.greenlightPassed++;
            manager.UpdateUI();
            if (StatTracker.greenlightPassed >= requiredCorrectAttempts)
            {
                StatTracker.redlightPassed = 0;
                StatTracker.greenlightPassed = 0;
                manager.UpdateUI();
                tutorialZonesController.LoadNextZone();
            }
        }

    }

}
