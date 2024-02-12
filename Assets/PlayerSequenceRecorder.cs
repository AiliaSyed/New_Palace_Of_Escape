using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerSequenceRecorder : MonoBehaviour
{
    public static PlayerSequenceRecorder Instance { get; private set; }
    public GameObject Portal;
    public GameObject Podest;
    public GameObject paper;
    public GameObject[] houseTriggers;


    private List<string> playerSequence = new List<string>();
    private string[] correctSequence = new string[] { "North", "East", "West", "South" };
    public bool isRedPhase = false; // Muss von dem Ampelsystem gesetzt werden, wenn alle Ampeln rot sind

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RecordEntry(string houseName)
    {
        if (isRedPhase)
        {
            playerSequence.Add(houseName);
            if (playerSequence.Count == correctSequence.Length)
            {
                CheckSequence();
            }
        }
    }

    private void CheckSequence()
    {
        for (int i = 0; i < correctSequence.Length; i++)
        {
            Debug.Log(playerSequence[i]);
            if (playerSequence[i] != correctSequence[i])
            {
                Debug.Log("Falsche Reihenfolge");
                foreach (GameObject trigger in houseTriggers)
                {
                    trigger.GetComponent<HouseTrigger>().isRecorded = false;   
                }
                return;
            }
        }
        Debug.Log("Richtige Reihenfolge, Tür öffnen oder nächste Aufgabe");
        Portal.SetActive(true);
        Podest.SetActive(false);
        paper.SetActive(false);
    }

    public void StartRedPhase()
    {
        isRedPhase = true;
        playerSequence.Clear();
    }

    public void EndRedPhase()
    {
        isRedPhase = false;
        playerSequence.Clear(); // Bereite für die nächste Runde vor
    }
}

