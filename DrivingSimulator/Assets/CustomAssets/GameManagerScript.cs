using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField]
    private int maxScore;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI reasonText;

    [SerializeField]
    private CarControllerScript player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int modifier, string message)
    {
        player.score += modifier;
        scoreText.text = "Demerits: " + player.score;
        reasonText.text = message;

        if (player.score > maxScore)
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
