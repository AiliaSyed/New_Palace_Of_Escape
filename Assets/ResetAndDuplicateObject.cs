using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAndDuplicateObject : MonoBehaviour
{
    public GameObject objectToReset; // Das Objekt, das zurückgesetzt werden soll
    public GameObject objectToDuplicate; // Das Objekt, das dupliziert werden soll

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        // Speichere die ursprüngliche Position und Rotation des Objekts
        originalPosition = objectToReset.transform.position;
        originalRotation = objectToReset.transform.rotation;
    }

    public void ResetAndDuplicate()
    {
        // Setze das Objekt auf seine ursprüngliche Position und Rotation zurück
        objectToReset.transform.position = originalPosition;
        objectToReset.transform.rotation = originalRotation;

        originalPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z - 0.1f);

        // Erstelle ein Duplikat des anderen Objekts an derselben Position
        Instantiate(objectToDuplicate, originalPosition, originalRotation);
        originalPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z + 0.1f);
    }
}

