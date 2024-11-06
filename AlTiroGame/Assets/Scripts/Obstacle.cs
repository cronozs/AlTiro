using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _health = 5;

    private void OnTriggerEnter(Collider other)
    {
        if(_health <=0)
        {
            Death();
        }
    }
    private void Death()
    {
        this.gameObject.SetActive(false);
    }
}
