using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachLever : MonoBehaviour
{
    public GameObject SnapLever;
    public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public AudioSource audioSource;


    void Start()
    {
        // Zu Beginn Objekt A verstecken
        objectA.SetActive(false);

    }

    void Update()
    {
        // Überprüfen, ob Objekt C das SnapZoneOffset-Skript hat
        if (objectC.GetComponent<SnapZoneOffset>() != null)
        {
            // Objekt B und C verstecken und Objekt A sichtbar machen
            objectB.SetActive(false);
            objectC.SetActive(false);
            SnapLever.SetActive(false);
            objectA.SetActive(true);

            // Spiele den Ton ab
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Optional: Deaktivieren des Updates, nachdem die Änderung einmal vorgenommen wurde
            this.enabled = false;

            
        }
    }
}


