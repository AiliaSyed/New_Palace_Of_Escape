using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOff : MonoBehaviour
{
    public MonoBehaviour smoothLocomotionScript;
    public MonoBehaviour playerTeleportScript;

    void Start()
    {
        // Zu Beginn SmoothLocomotion aktivieren und PlayerTeleport deaktivieren
        smoothLocomotionScript.enabled = false;
        playerTeleportScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
