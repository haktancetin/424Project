using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI greenLightPassedText;
    [SerializeField] TextMeshProUGUI redLightsPassedText;

    public void GreenLightPassed()
    {
        greenLightPassedText.text = StatTracker.greenlightPassed.ToString();
    }

    public void RedLightPassed()
    {
        redLightsPassedText.text = StatTracker.redlightPassed.ToString();
    }


}
