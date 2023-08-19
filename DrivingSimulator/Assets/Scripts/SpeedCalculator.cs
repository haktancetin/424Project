using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpeedCalculator : MonoBehaviour
{

    [SerializeField]
    private GameObject speedTextObject;

    [SerializeField]
    private Rigidbody carRb;

    [SerializeField]
    private Text speedText;
    // Start is called before the first frame update
    void Start()
    {
        speedTextObject = GameObject.Find("Speed Text");
        speedText = speedTextObject.GetComponent<Text>();
        carRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = (carRb.velocity.magnitude * 3.6f).ToString("F0");
    }
}
