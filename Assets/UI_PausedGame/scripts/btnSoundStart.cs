using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSoundStart : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip start;

    public void playSound()
    {
        sound.PlayOneShot(start);
    }
}
