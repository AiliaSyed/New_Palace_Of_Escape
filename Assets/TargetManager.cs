using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targets; // Array aller Targets
    public int[] correctOrder; // Die korrekte Reihenfolge der Targets
    private int[] shotOrder; // Die Reihenfolge, in der die Targets erschossen wurden
    private int currentIndex = 0; // Der aktuelle Index im shotOrder-Array
    public GameObject Door;
    public GameObject SouthStatue;
    public bool DoorOpened;

    void Start()
    {
        shotOrder = new int[targets.Length]; // Initialisiere das shotOrder-Array
        DoorOpened = false;
    }

    void Update()
    {
        // �berpr�fe, ob alle Targets deaktiviert sind
        if (AllTargetsDestroyed())
        {
            CheckOrderAndProceed();
        }
    }

    // Hilfsmethode, um zu �berpr�fen, ob alle Targets deaktiviert sind
    private bool AllTargetsDestroyed()
    {
        foreach (GameObject target in targets)
        {
            if (target.activeSelf)
            {
                // Mindestens ein Target ist noch aktiv
                return false;
            }
        }
        // Alle Targets sind deaktiviert
        return true;
    }

    // Diese Methode wird von den Target-Skripten aufgerufen, wenn sie zerst�rt werden
    public void TargetDestroyed(int targetID)
    {
        shotOrder[currentIndex] = targetID;
        currentIndex++;

        Wait(1);
        targets[targetID - 1].SetActive(false);

        if (currentIndex >= targets.Length)
        {
            CheckOrderAndProceed();
        }

    }
    private IEnumerator Wait(int i)
    {
        yield return new WaitForSeconds(i);
    }

    void CheckOrderAndProceed()
    {
        // �berpr�fe, ob die Reihenfolge korrekt ist
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (correctOrder[i] != shotOrder[i])
            {
                Debug.Log("Falsche Reihenfolge, respawn Targets");
                RespawnTargets();
                return;
            }
        }

        // Richtige Reihenfolge, �ffne T�r oder triggere den n�chsten Schritt
        if (!DoorOpened)
        {
            OpenDoor();
            DoorOpened = true;
        }
        
    }

    void RespawnTargets()
    {
        foreach (GameObject target in targets)
        {
            target.SetActive(true); // Aktiviere die Targets wieder
        }
        currentIndex = 0; // Setze den Index zur�ck
    }

    void OpenDoor()
    {
        OpenDoors myScript = Door.GetComponent<OpenDoors>();
        myScript.StartRotationLeftDoor();
    }

}

