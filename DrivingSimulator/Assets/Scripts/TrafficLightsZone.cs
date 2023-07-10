using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsZone : TutorialZone 
{
    private int requiredCorrectAttempts = 4;

    public void CheckFailSuccess(TrafficLightController.Lightcolor light) {

        float carSpeed = carController.carSpeed;

        if (light == TrafficLightController.Lightcolor.red)
        {
            if (carSpeed > 0)
            {
                wrongAttempts++;

                if (wrongAttempts >= 2)
                {
                    tutorialZonesController.RestartTutorial();
                    wrongAttempts = 0; // Yanlýþ yapma hakký sýfýrlanýyor
                }
            }
            else
            {
                correctAttempts++;

                if (correctAttempts >= requiredCorrectAttempts)
                {
                    tutorialZonesController.LoadNextZone();
                }
            }
        }
        else if (light == TrafficLightController.Lightcolor.green)
        {
            if (carSpeed > 0)
            {
                correctAttempts++;

                if (correctAttempts >= requiredCorrectAttempts)
                {
                    tutorialZonesController.LoadNextZone();
                }
            }
            else
            {
                wrongAttempts++;

                if (wrongAttempts >= 2)
                {
                    tutorialZonesController.RestartTutorial();
                    wrongAttempts = 0;
                }
            }
        }
        else
        {
            // Sarý ýþýk durumunda kontrol 
        }

    }
   
}
