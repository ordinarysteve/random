using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNearestPlayer : MonoBehaviour
{

    public GameObject targetObject;
    public GameObject[] allObjects;

    void Start()
    {
        allObjects = GameObject.FindGameObjectsWithTag("Destinations");
    }

    void Update()
    {
        FindNearest();
    }

    void FindNearest()
    {
        GameObject nearestObject = allObjects[0];
        float shortestDistance = Vector3.Distance(targetObject.transform.position, nearestObject.transform.position);

        for (int i = 1; i < allObjects.Length; i++)
        {
            float currentDistance = Vector3.Distance(targetObject.transform.position, allObjects[i].transform.position);

            if (currentDistance < shortestDistance)
            {
                nearestObject = allObjects[i];
                shortestDistance = currentDistance;
            }

        }
    }
}
