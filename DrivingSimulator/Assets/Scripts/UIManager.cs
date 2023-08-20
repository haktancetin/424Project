using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI greenLightPassedText;
    [SerializeField] TextMeshProUGUI redLightsPassedText;

    public void UpdateUI()
    {
        greenLightPassedText.text = StatTracker.greenlightPassed.ToString();
        redLightsPassedText.text = StatTracker.redlightPassed.ToString();
    }

}
