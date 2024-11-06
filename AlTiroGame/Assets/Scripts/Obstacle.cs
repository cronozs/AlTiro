using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
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
    }
}
