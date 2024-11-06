using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpowner : MonoBehaviour
{
    [SerializeField] private ObstaclePooling obstaclePolling;
    [SerializeField] private float[] spownIntervalRange;
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
