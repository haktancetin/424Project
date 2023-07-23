using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private GameManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "PlayerCar"){
            //GameObject.SetActive(false);
            gameManager.UpdateScore(3, "Hit pedestrian!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
