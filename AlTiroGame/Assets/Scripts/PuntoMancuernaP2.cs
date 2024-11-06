using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoMancuernaP2 : MonoBehaviour
{
    public Transform EmptySpawn;
    public GameObject PrefabMancuerna;
    public float bulletSpeed = 10f;
    private float timeBetweenPresses = 2.5f;
    private float timeSinceLastPress = 0f;

    private void Update()
    {
        timeSinceLastPress += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) && timeSinceLastPress >= timeBetweenPresses)
        {
            var bullet = Instantiate(PrefabMancuerna, EmptySpawn.position, EmptySpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = EmptySpawn.forward * bulletSpeed;

            timeSinceLastPress = 0f;
        }
    }
}
