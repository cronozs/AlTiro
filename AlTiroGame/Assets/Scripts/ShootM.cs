using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootM : MonoBehaviour
{
    public Transform EmptySpawn;
    public GameObject PrefabArma;
    public float bulletSpeed = 10f;
    public float timeBetweenPresses = 2f;
    public string shootManager;
    public bool canShoot;
    public float dir;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis(shootManager) > 0 && canShoot)
        {
            var bullet = Instantiate(PrefabArma, EmptySpawn.position, PrefabArma.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.right * bulletSpeed * dir;
            canShoot = false;
            StartCoroutine(DelayToShoot());
        }
    }

    IEnumerator DelayToShoot()
    {
        yield return new WaitForSeconds(timeBetweenPresses);
        canShoot = true;
    }
}
