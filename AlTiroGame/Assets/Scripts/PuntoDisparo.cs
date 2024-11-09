using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDisparo : MonoBehaviour
{
    public Transform EmptySpawn;
    public GameObject PrefabArma;
    public float bulletSpeed = 10f;
    public float timeBetweenPresses = 2f;
    private float timeSinceLastPress = 0f;
    public string keyCodeString;

    void Update()
    {
        timeSinceLastPress += Time.deltaTime;

        KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyCodeString);

        if (Input.GetKeyDown(keyCode) && timeSinceLastPress >= timeBetweenPresses)
        {
            var bullet = Instantiate(PrefabArma, EmptySpawn.position, EmptySpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = EmptySpawn.forward * bulletSpeed;

            timeSinceLastPress = 0f;
        }
    }
}
