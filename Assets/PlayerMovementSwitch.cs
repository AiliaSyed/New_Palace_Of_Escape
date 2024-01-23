using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSwitch : MonoBehaviour
{
    public MonoBehaviour smoothLocomotionScript;
    public MonoBehaviour playerTeleportScript;

    void Start()
    {
        // Zu Beginn SmoothLocomotion aktivieren und PlayerTeleport deaktivieren
        smoothLocomotionScript.enabled = false;
        playerTeleportScript.enabled = true;
    }

    void Update()
    {
        // �berpr�fen, ob die Y-Taste gedr�ckt wurde
        if (InputBridge.Instance.YButton)
        {
            // Wechseln zwischen den beiden Bewegungsmodi
            ToggleMovementMode();
        }
    }

    private void ToggleMovementMode()
    {
        // Aktuellen Status von SmoothLocomotion �berpr�fen und umschalten
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


