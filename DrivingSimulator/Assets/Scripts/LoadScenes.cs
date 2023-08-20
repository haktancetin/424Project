using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void TrainingSceneLoad()
    {
        SceneManager.LoadScene("TrainingScene");
    }

    public void DrivingExamSceneLoad()
    {
        SceneManager.LoadScene("DrivingExamScene");
    }
}
