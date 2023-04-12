using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stasSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        audioSource.PlayOneShot(clip);
    }

}
