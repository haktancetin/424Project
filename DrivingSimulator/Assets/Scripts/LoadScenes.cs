using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void TrainingSceneLoad()
    {
        SceneManager.LoadScene(1);
    }

    public void DrivingExamSceneLoad()
    {
        SceneManager.LoadScene(2);
    }

    public void FreeRideSceneLoad()
    {
        SceneManager.LoadScene(3);
    }

    public void MainMenuSceneLoad()
    {
        SceneManager.LoadScene(0);
    }
}
