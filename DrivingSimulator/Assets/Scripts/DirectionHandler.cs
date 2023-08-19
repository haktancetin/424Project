using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DirectionHandler : MonoBehaviour
{
    public GameObject warningObject;
    public Text warningText;

    private void Start()
    {
        warningObject = GameObject.Find("WarningText");
        warningText = warningObject.GetComponent<Text>();
    }

    private void Update()
    {

        if (warningObject == null)
        {
            warningObject = GameObject.Find("WarningText");
            warningText = warningObject.GetComponent<Text>();
            Debug.Log("ready set");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in Trigger!");
            warningText.text = "Wrong Side!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Left Trigger!");
            warningText.text = "";
        }
    }
}
