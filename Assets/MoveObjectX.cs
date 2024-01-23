using UnityEngine;

public class MoveObjectX : MonoBehaviour
{
    public float moveDistance = 1.0f; // Der Wert, um den das Objekt in der X-Richtung bewegt wird
    public float moveSpeed = 1.0f; // Geschwindigkeit der Bewegung

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        // Speichere die Startposition
        startPosition = transform.position;
        // Berechne die Zielposition
        targetPosition = new Vector3(startPosition.x + moveDistance, startPosition.y, startPosition.z);
    }

    // Öffentliche Methode zum Starten der Bewegung
    public void TriggerMovement()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToPosition(targetPosition, moveSpeed));
        }
    }

    System.Collections.IEnumerator MoveToPosition(Vector3 target, float speed)
    {
        isMoving = true;
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }
}
