using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public float duration = 1.0f; // Dauer der Drehung in Sekunden
    public GameObject SouthTarget;

    public void StartRotationLeftDoor()
    {
        if (LeftDoor != null)
        {
            StartCoroutine(RotateOverTime(LeftDoor, Vector3.up, -90, duration));
        }
    }
    public void StartRotationRightDoor()
    {
        if (LeftDoor != null)
        {
            StartCoroutine(RotateOverTime(RightDoor, Vector3.up, 90, duration));
        }
        SouthTarget.SetActive(true);
    }

    private IEnumerator RotateOverTime(GameObject obj, Vector3 axis, float angle, float duration)
    {
        Quaternion originalRotation = obj.transform.rotation;
        Quaternion targetRotation = obj.transform.rotation * Quaternion.Euler(axis * angle);
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            obj.transform.rotation = Quaternion.Lerp(originalRotation, targetRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.rotation = targetRotation; // Stelle sicher, dass das Ziel exakt erreicht wird
    }
}
