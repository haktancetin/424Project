using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParkingUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI parkingText;
    [SerializeField] ParkingZone parkingZoneScript;

    private void OnEnable()
    {
        parkingZoneScript.OnParkComplete += UpdateParkingText;
    }

    void UpdateParkingText()
    {
        parkingText.text = StatTracker.parkingCompleted.ToString();
    }


}
