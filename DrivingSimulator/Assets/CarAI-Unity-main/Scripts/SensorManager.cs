using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager : MonoBehaviour
{
    private CarAI carAI;

    void Start()
    {
        carAI = gameObject.transform.parent.GetComponent<CarAI>();
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("TrafficLight"))
        {
            TrafficLightController trafficLightController = col.gameObject.GetComponent<TrafficLightController>();

            //Only trigger behaviour if collider is entered from the back - the traffic light faces that way

            Vector3 triggerFrontDirection = col.gameObject.transform.forward;
            
            //Calculate the vector from the trigger to the entering object
            Vector3 triggerToEnteringObject = col.transform.position - transform.position;

            //Normalize both vectors for accurate dot product calculation
            triggerFrontDirection.Normalize();
            triggerToEnteringObject.Normalize();

            //Calculate the dot product
            float dotProduct = Vector3.Dot(triggerFrontDirection, triggerToEnteringObject);

            if (dotProduct > 0)
            {
                //Debug.Log("Object entered from the front.");
            }
            else
            {
                //Debug.Log("Object entered from the back.");
                //If red or yellow are active, stop the car, if green is active, continue
                while(trafficLightController.redLight.activeSelf || trafficLightController.yellowLight.activeSelf)
                {
                    carAI.move = false;
                }
                carAI.move = true;
            }

        }
        else if (col.gameObject.CompareTag("Car"))
        {
            //stop if colliding with car
            carAI.move = false;
        }

    }

    private void OnTriggerExit(Collider col)
    {
        carAI.move = true;
    }
}
