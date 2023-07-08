using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField]
    private int maxScore;

    [SerializeField]
    private CarControllerScript player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int modifier, string message)
    {
        player.score += modifier;
        if(player.score > maxScore)
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
