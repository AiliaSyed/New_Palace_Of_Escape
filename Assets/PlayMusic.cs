using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Stelle sicher, dass die AudioSource-Komponente zugewiesen ist
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void ToggleAudio()
    {
        // Überprüfe, ob die AudioSource aktiv ist, und schalte sie um
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
}
