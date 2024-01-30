using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSwitch : MonoBehaviour
{
    public MonoBehaviour smoothLocomotionScript;
    public MonoBehaviour playerTeleportScript;
    public float delayBetweenToggles = 0.5f; // Verzögerung zwischen Toggles in Sekunden
    private float timeSinceLastToggle = 0;

    void Start()
    {
        // Zu Beginn SmoothLocomotion aktivieren und PlayerTeleport deaktivieren
        smoothLocomotionScript.enabled = false;
        playerTeleportScript.enabled = true;
    }

    void Update()
    {
        timeSinceLastToggle += Time.deltaTime;
        if (InputBridge.Instance.YButton && timeSinceLastToggle >= delayBetweenToggles)
        {
            timeSinceLastToggle = 0; // Timer zurücksetzen

            // Wechseln zwischen den beiden Bewegungsmodi
            ToggleMovementMode();
        }
    }

    private void ToggleMovementMode()
    {
        // Aktuellen Status von SmoothLocomotion überprüfen und umschalten
        if (smoothLocomotionScript.enabled)
        {
            smoothLocomotionScript.enabled = false;
            playerTeleportScript.enabled = true;
        }
        else
        {
            smoothLocomotionScript.enabled = true;
            playerTeleportScript.enabled = false;
        }
    }
}


