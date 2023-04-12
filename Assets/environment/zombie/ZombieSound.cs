using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    public AudioSource sourceMoan;
    public AudioSource sourceSteps;

    private void Start()
    {
        sourceMoan.PlayDelayed(Random.Range(3, 20));
        sourceSteps.PlayDelayed(5);
    }
}
