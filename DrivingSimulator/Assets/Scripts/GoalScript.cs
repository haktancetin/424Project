using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    [SerializeField]
    private GameManagerScript gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerCar")
        {
            gameManager.Victory();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
