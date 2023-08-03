using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float DestroyTime = 3f;

    private void Start()
    {
        Destroy(gameObject, DestroyTime);       
    }
}
