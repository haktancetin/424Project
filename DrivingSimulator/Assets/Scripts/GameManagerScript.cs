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
    public float speedLimit;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI reasonText;

    [SerializeField]
    private TextMeshProUGUI speedText;

    [SerializeField]
    private CarControllerScript player;

    [SerializeField]
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        speedText.text = "Speed Limit: " + speedLimit + " km/h";
    }

    IEnumerator MessageFlash(string message)
    {
        reasonText.text = message;
        yield return new WaitForSeconds(3);
        reasonText.text = "";
        yield return null;
    }

    //Handle demerits and possibly rewards
    public void UpdateScore(int modifier, string message)
    {
        player.score += modifier;
        scoreText.text = "Demerits: " + player.score;
        StartCoroutine(MessageFlash(message));

        if (player.score > maxScore)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
        }
    }

    public void Victory()
    {
        reasonText.color = Color.green;
        reasonText.text = "Course completed!";
        Time.timeScale = 0;
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRB.velocity.magnitude * 3.6f > speedLimit)
        {
            UpdateScore(2, "Speeding!");
        }
    }
}
