using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            LoadNextZone();
        }
    }

    public void CreateTutorialZone(int index)
    {
        Debug.Log("Index is "+ index);
        if (index >= 0 && index < tutorialZones.Length)
        {
            GameObject tutorialZone;
            if(index == 0)
            {
                tutorialZone = Instantiate(tutorialZones[index].gameObject, new Vector3(0, 0,0), Quaternion.identity);

            }
            else
            {
                tutorialZone = Instantiate(tutorialZones[index].gameObject, new Vector3(0, 15, 0), Quaternion.identity);
            }

            currentTutorialZone = tutorialZone;
        }
        else
        {
            Debug.Log("Geçersiz bölge indeksi: " + index);
        }
    }

    public void RestartTutorial()
    {
        //Destroy(currentTutorialZone);
        //CreateTutorialZone(zoneIndex);

        SceneManager.LoadScene("TrainingScene");
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
