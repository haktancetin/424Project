using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingSlot : MonoBehaviour
{
    ParkingZone parkingZoneScript;
    public GameObject player;
    public Rigidbody playerRb;

    [HideInInspector]
    public int Counter;

    [SerializeField] List<GameObject> parkingZoneCheckers = new List<GameObject>();

    private bool parkingCompleted;

    private void Start()
    {
        parkingCompleted = false;
        parkingZoneScript = GetComponentInParent<ParkingZone>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        parkingCompleted = false;
    }

    private void Update()
    {
        parkingCompleted = false;
        
        if (player != null)
        {
            Debug.Log(Counter);
            if (Counter == 4 && !parkingCompleted)
            {
                Debug.Log("4!");
                if (playerRb.velocity.magnitude < 0.1f)
                {
                    parkingCompleted = true;
                    parkingZoneScript.OnParkComplete();
                    Counter = 0;
                    
                }
            }
        }
        else
        {
            Debug.Log("player null");
            player = GameObject.FindGameObjectWithTag("Player");
            playerRb = player.GetComponent<Rigidbody>();
        }
    }
}
