using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    public string houseName;
    public GameObject house;
    private PlayerSequenceRecorder playerSequenceRecorder;
    public bool isRecorded;

    private void OnTriggerEnter(Collider other)
    {
        playerSequenceRecorder = FindObjectOfType<PlayerSequenceRecorder>();
        if (other.CompareTag("Player"))
        {
            if (playerSequenceRecorder.isRedPhase && !isRecorded)
            {
                PlayerSequenceRecorder.Instance.RecordEntry(houseName);
                isRecorded = true;
            }
            StartCoroutine(ResetFurniture());
        }
    }

    private IEnumerator ResetFurniture()
    {
        yield return new WaitForSeconds(3);
        house.GetComponent<FurnitureManager>().ResetFurniture();
    }
}


