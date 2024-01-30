using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKnight : MonoBehaviour
{
    public GameObject objectToRotate; // Das GameObject, dessen Rotation geändert wird

    // Methode zum Setzen der Rotation
    public void SetObjectRotation(Vector3 newRotation, Vector3 newPosition)
    {
        if (objectToRotate != null)
        {
            // Setze die Rotation des Objekts auf die neuen Werte
            objectToRotate.transform.eulerAngles = newRotation;
            objectToRotate.transform.position = newPosition;
        }


    }
}
