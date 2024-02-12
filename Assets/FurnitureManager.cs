using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Furniture
{
    public GameObject furnitureObject;
    public Vector3 originalPosition;
    public Quaternion originalRotation;
}

public class FurnitureManager : MonoBehaviour
{
    public Furniture[] furnitureItems; // Array für die Möbelstücke

    void Start()
    {
        // Speichere die ursprünglichen Transform-Werte jedes Möbelstücks
        foreach (Furniture furniture in furnitureItems)
        {
            furniture.originalPosition = furniture.furnitureObject.transform.position;
            furniture.originalRotation = furniture.furnitureObject.transform.rotation;
        }
    }

    // Methode zum Zurücksetzen der Möbelstücke
    public void ResetFurniture()
    {
        foreach (Furniture furniture in furnitureItems)
        {
            furniture.furnitureObject.transform.position = furniture.originalPosition;
            furniture.furnitureObject.transform.rotation = furniture.originalRotation;
        }
    }

}
