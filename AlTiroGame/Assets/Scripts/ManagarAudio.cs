using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagarAudio : MonoBehaviour
{
    public static ManagarAudio Instance;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this )
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public void ChangeAudio(AudioSource audioSource, AudioClip clip)
    {
        audioSource.clip = clip;
    }
   
    public void CreateParticle(GameObject particle)
    {
        Instantiate(particle, particle.transform.position, Quaternion.identity);
    }
}
