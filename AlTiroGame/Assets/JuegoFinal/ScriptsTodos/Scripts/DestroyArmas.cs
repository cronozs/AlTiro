using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArmas : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
