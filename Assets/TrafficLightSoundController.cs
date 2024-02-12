using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSoundController : MonoBehaviour
{
    private AudioSource audioSource;

    // Start wird vor dem ersten Frame-Update aufgerufen
    void Start()
    {
        // Versuche, die AudioSource-Komponente zu erhalten
        audioSource = GetComponent<AudioSource>();
    }

    // Methode zum Aktivieren der AudioSource
    public void EnableSound()
    {
        if (audioSource != null)
        {
            audioSource.enabled = true;
            audioSource.Play(); // Startet die Wiedergabe, wenn nicht bereits geschehen
        }
    }

    // Methode zum Deaktivieren der AudioSource
    public void DisableSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop(); // Stoppt die Wiedergabe
            audioSource.enabled = false;
        }
    }
}
