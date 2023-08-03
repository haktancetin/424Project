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
            wrongAttempts++;
            manager.RedLightPassed();

            if (wrongAttempts >= 2)
            {
                tutorialZonesController.RestartTutorial();
                wrongAttempts = 0; // Yanlis yapma hakkini resetler
            }
        }
        else
        {
            correctAttempts++;
            StatTracker.greenlightPassed++;
            manager.GreenLightPassed();
            Debug.Log("Green Light Passed");
            if (correctAttempts >= requiredCorrectAttempts)
            {
                tutorialZonesController.LoadNextZone();
            }
        }
      
    }
   
}
