using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoChanclaP1 : MonoBehaviour
{
    public Transform EmptySpawn;
    public GameObject PrefabChancla;
    public float bulletSpeed = 10f;
    private float timeBetweenPresses = 1.5f;
    private float timeSinceLastPress = 0f;

    private void Update()
    {
        timeSinceLastPress += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && timeSinceLastPress >= timeBetweenPresses)
        {
            var bullet = Instantiate(PrefabChancla, EmptySpawn.position, EmptySpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = EmptySpawn.forward * bulletSpeed;

            timeSinceLastPress = 0f;
        }
    }
}
