using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveObjectInFrontOfPlayer : MonoBehaviour
{
    public GameObject objectToMove; // Das zu bewegende Objekt
    public Transform playerHand;
    public float spawnDistance = 0.3f; // Der Abstand vor der Kamera, an dem das Objekt erscheinen soll

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isAtOriginalPosition = true;
    public float delayBetweenToggles = 0.5f; // Verzögerung zwischen Toggles in Sekunden
    private float timeSinceLastToggle = 0;

    void Start()
    {
        // Speichere die ursprüngliche Position und Rotation
        originalPosition = objectToMove.transform.position;
        originalRotation = objectToMove.transform.rotation;
    }
    void Update()
    {
        // Aktualisiere den Timer
        timeSinceLastToggle += Time.deltaTime;
        if (InputBridge.Instance.XButton && timeSinceLastToggle >= delayBetweenToggles)
        {
            timeSinceLastToggle = 0; // Timer zurücksetzen

            if (isAtOriginalPosition)
            {
                MoveObjectToFront();
                RotateObjectTowardsPlayer();
            }
            else
            {
                MoveObjectBack();
            }
            isAtOriginalPosition = !isAtOriginalPosition;
        }
    }

    void MoveObjectBack()
    {
        objectToMove.transform.position = originalPosition;
        objectToMove.transform.rotation = originalRotation;
    }



    void MoveObjectToFront()
    {
        if (objectToMove != null && playerHand != null)
        {
            // Berechne die Position vor der Kamera
            Vector3 spawnPosition = playerHand.position + playerHand.forward * spawnDistance;

            // Bewege das Objekt an diese Position und aktiviere es
            objectToMove.transform.position = spawnPosition;
        }
    }


    void RotateObjectTowardsPlayer()
    {
        if (objectToMove != null && playerHand != null)
        {
            // Rotiere das Objekt, so dass es zur Kamera zeigt
            // Hier wird angenommen, dass die "Vorderseite" des Objekts in Richtung der lokalen Z-Achse zeigt
            Vector3 directionToPlayer = playerHand.position - objectToMove.transform.position;
            directionToPlayer.y = 0; // Optional: Ignoriere die Y-Komponente, um nur eine Drehung entlang der Y-Achse zu haben
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            objectToMove.transform.rotation = lookRotation;

            // Füge eine zusätzliche Drehung von -90 Grad um die Y-Achse hinzu
            Quaternion additionalRotation = Quaternion.Euler(0, -90, 0);
            objectToMove.transform.rotation = lookRotation * additionalRotation;
        }
    }
}
