using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Methode zum Beenden des Spiels
    public void QuitGame()
    {
        // Debug.Log wird verwendet, um die Funktion im Editor zu überprüfen
        Debug.Log("Spiel beenden wurde aufgerufen");

        // Beendet das Spiel, wenn es außerhalb des Editors ausgeführt wird
        Application.Quit();
    }
}

