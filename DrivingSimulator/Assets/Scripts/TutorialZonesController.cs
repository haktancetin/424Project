using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TutorialZonesController : MonoBehaviour
{
    [SerializeField] TutorialZone[] tutorialZones;
    private int zoneIndex = -1;

    public GameObject currentTutorialZone = null;

    private void Start()
    {
        LoadNextZone();
    }

    public void CreateTutorialZone(int index)
    {
        if (index >= 0 && index < tutorialZones.Length)
        {
            GameObject tutorialZone = Instantiate(tutorialZones[index].gameObject, Vector3.zero, Quaternion.identity);
            currentTutorialZone = tutorialZone;
        }
        else
        {
            Debug.Log("Geçersiz bölge indeksi: " + index);
        }
    }

    public void RestartTutorial()
    {
        Destroy(currentTutorialZone);
        CreateTutorialZone(zoneIndex);
    }

    public void LoadNextZone()
    {
        if (zoneIndex + 1 < tutorialZones.Length)
        {
            zoneIndex++;
            Destroy(currentTutorialZone);
            CreateTutorialZone(zoneIndex);
        }
        else
        {
            Debug.Log("Tüm bölgeler tamamlandı.");
        }
       
    }

}
