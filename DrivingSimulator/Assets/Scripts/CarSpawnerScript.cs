using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{

    [SerializeField]
    public GameObject[] cars;

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            GameObject carToSpawn = cars[Random.Range(0, cars.Length)];
            carToSpawn.SetActive(true);
            carToSpawn.transform.position = transform.position;
            carToSpawn.transform.forward = transform.forward;
            Instantiate(carToSpawn);
            yield return new WaitForSeconds(10f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoCheck());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
