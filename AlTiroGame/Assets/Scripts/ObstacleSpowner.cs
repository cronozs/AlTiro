using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpowner : MonoBehaviour
{
    [Tooltip("Referencia al obstaclepooling dentro de la escena")]
    [SerializeField] private ObstaclePooling obstaclePolling;
    [Tooltip("rango de tiempo en el cual se pueden crear obstaculos nuevos")]
    [SerializeField] private float[] spownIntervalRange;
    [Tooltip("Rango en el que se pueden crear los obstaculos")]
    [SerializeField] private Vector3[] SpawnRange;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayToSpawn());
    }

    IEnumerator DelayToSpawn()
    {
        yield return new WaitForSeconds(Random.Range(spownIntervalRange[0], spownIntervalRange[1]));
        obstaclePolling.AskForObject(new Vector3(Random.Range(SpawnRange[0].x, SpawnRange[1].x), Random.Range(SpawnRange[0].y, SpawnRange[1].y), Random.Range(SpawnRange[0].z, SpawnRange[1].z)));
        StartCoroutine(DelayToSpawn());
    }
}
