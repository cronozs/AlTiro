using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoCueteP1 : MonoBehaviour
{
    public Transform EmptySpawn;
    public GameObject PrefabCuete;
    public float bulletSpeed = 10f;
    private float timeBetweenPresses = 1f;
    private float timeSinceLastPress = 0f;

    private void Update()
    {
        timeSinceLastPress += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && timeSinceLastPress >= timeBetweenPresses)
        {
            var bullet = Instantiate(PrefabCuete, EmptySpawn.position, EmptySpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = EmptySpawn.forward * bulletSpeed;

            timeSinceLastPress = 0f;
        }
    }
}
