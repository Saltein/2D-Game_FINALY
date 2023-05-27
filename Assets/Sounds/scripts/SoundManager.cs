using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    public void ToggleSound()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.enabled = !audioSource.enabled;
        }
    }
}