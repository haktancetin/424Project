using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public enum Lightcolor
    {
        red,
        yellow,
        green
    }
   
    public GameObject redLight, yellowLight, greenLight;
    public TrafficLightsZone trafficLightsZone;

    Lightcolor lightcolor;

    public float timer = 0;
    private float redtimer, yellowtimer, greentimer;
   
    void Start()
    {
        redtimer = 5f;
        yellowtimer = 1.5f;
        greentimer = 3f;
    }
    
    void Update()
    {
        changeLights();
    }

    void changeLights()
    {
        timer += Time.deltaTime;
        if (timer >= 0f && timer < redtimer)
        {
            lightcolor = Lightcolor.red;
            redLight.SetActive(true);
            yellowLight.SetActive(false);
            greenLight.SetActive(false);
        }
        else if (timer >= redtimer && timer < redtimer + yellowtimer)
        {
            lightcolor = Lightcolor.yellow;
            redLight.SetActive(false);
            yellowLight.SetActive(true);
            greenLight.SetActive(false);
        }
        else if (timer >= redtimer + yellowtimer && timer < redtimer + yellowtimer + greentimer)
        {
            lightcolor = Lightcolor.green;
            redLight.SetActive(false);
            yellowLight.SetActive(false);
            greenLight.SetActive(true);
        }
        else
        {
            timer = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Traffic light triggered by car");

        if (other.CompareTag("Car"))
        {
            trafficLightsZone.CheckFailSuccess(lightcolor);
        }
    }

}
