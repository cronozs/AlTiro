using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooling : MonoBehaviour
{
    public GameObject obstacle;
    public List<GameObject> createdObjects;
    void Start()
    {
        createdObjects = new List<GameObject>();
    }

    public GameObject AskForObject(Vector3 posToSpawn)
    {
        for (int indexObjects = 0; indexObjects < createdObjects.Count; indexObjects++)
        {
            if (!createdObjects[indexObjects].activeInHierarchy)
            {
                createdObjects[indexObjects].SetActive(true);
                return createdObjects[indexObjects];
            }
        }
        GameObject createdObject = Instantiate(obstacle, posToSpawn, Quaternion.identity);
        createdObjects.Add(createdObject);
        return createdObject;
    }
}
