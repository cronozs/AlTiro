using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Tooltip("Rango en el que se pueden crear los obstaculos")]
    [SerializeField] private Vector3[] SpawnRange;
    private float _health = 5;
 
    private void OnTriggerEnter(Collider other)
    {
        Damage currentDamage = other.GetComponent<Damage>();
        _health -= currentDamage.damage;
        Destroy(other.gameObject);
        if(_health <=0)
        {
            Death();
        }
    }
    private void Death()
    {
        _health = 5;
        this.gameObject.SetActive(false);
        RepositionObtacle();
    }

    private void RepositionObtacle()
    {
        transform.position = new Vector3(Random.Range(SpawnRange[0].x, SpawnRange[1].x), Random.Range(SpawnRange[0].y, SpawnRange[1].y), Random.Range(SpawnRange[0].z, SpawnRange[1].z));
    }
}
