using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform EmptySpawn;    // Punto de spawn de las balas.
    public GameObject PrefabArma;   // Prefab del arma.
    public float bulletSpeed = 50f; // Velocidad de las balas.
    public float timeBetweenPresses; // Tiempo entre disparos.
    private string shootManager;    // Input manager para disparar.
    public bool canShoot = true;    // Control de disparo.
    public float dir;          // Direcci�n del disparo (1 o -1).

    void Update()
    {
        if (Input.GetAxis(shootManager) > 0 && canShoot)
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

    // M�todo para configurar el disparador y la direcci�n din�micamente.
    public void ConfigureShooting(string inputAxis, float direction)
    {
        shootManager = inputAxis;
        dir = direction;
    }
}
