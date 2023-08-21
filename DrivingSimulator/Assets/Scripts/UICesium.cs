using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICesium : MonoBehaviour
{
    

    public void Select(int index)
    {
        if(index == 0)
        {
            SceneManager.LoadScene(3);
        }else if(index == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
