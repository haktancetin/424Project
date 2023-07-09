using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TutorialZonesController : MonoBehaviour
{
    [SerializeField] TutorialZone[] tutorialZones;
    private static int zoneIndex;

    public static TutorialZonesController instance;
    public GameObject currentTutorialZone = null;

    private void Start()
    {
        if (zoneIndex == 0)
        {
            CreateTutorialZone(0);
        }
    }


    public void CreateTutorialZone(int index)
    {
        GameObject tutorialZone = Instantiate(tutorialZones[index].gameObject, Vector3.zero, Quaternion.identity);
        currentTutorialZone = tutorialZone;
    }

    public void LoadTutorialZone()
    {

    }

    public void RestartTutorial()
    {
        Destroy(currentTutorialZone);
        CreateTutorialZone(zoneIndex);
    }

    public void LoadNextZone()
    {
        zoneIndex++;
        Destroy(currentTutorialZone);
        CreateTutorialZone(zoneIndex);
    }

    public void Deneme()
    {
        Debug.Log("Hello");
    }
}
