using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float life = 1.5f;

    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit");
        }
    }

}
