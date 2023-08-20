using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{

    private GameObject car;
    private MeshFilter[] childMeshFilter;
    private Vector3[][] vertices;
    public static bool isCrashed;

    [SerializeField] private float deformationRadius = 0.5f;
    [SerializeField] private float impactDamage = 2f;


    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("PlayerCar");
        childMeshFilter = car.GetComponentsInChildren<MeshFilter>();

        vertices = new Vector3[childMeshFilter.Length][];

        for (int i = 0; i < childMeshFilter.Length; i++)
        {
            vertices[i] = childMeshFilter[i].mesh.vertices;
            childMeshFilter[i].mesh.MarkDynamic();
        }

        isCrashed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Building" || collision.gameObject.tag == "Goal")
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 contactVelocity = collision.relativeVelocity * 0.05f;

            for (int i = 0; i < childMeshFilter.Length; i++)
            {
                Crash(contactPoint, contactVelocity, i);
            }
        }
        
    }

    private void Crash(Vector3 contactPoint, Vector3 contactVelocity, int i)
    {
        Vector3 localContactPoint = childMeshFilter[i].transform.InverseTransformPoint(contactPoint);
        Vector3 localContactForce = childMeshFilter[i].transform.InverseTransformDirection(contactVelocity);
        Vector3[] meshVertices = childMeshFilter[i].mesh.vertices;

        for(int j = 0; j < meshVertices.Length; j++)
        {
            float distance = (localContactPoint - meshVertices[j]).magnitude;
            meshVertices[j] += localContactForce * (deformationRadius - distance) * impactDamage;

        }

        childMeshFilter[i].mesh.vertices = meshVertices;
        childMeshFilter[i].mesh.RecalculateNormals();
        childMeshFilter[i].mesh.RecalculateBounds();

     

        isCrashed = true;
    }
}
