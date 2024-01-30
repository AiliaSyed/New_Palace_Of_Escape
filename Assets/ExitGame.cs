using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Methode zum Beenden des Spiels
    public void QuitGame()
    {
        // Debug.Log wird verwendet, um die Funktion im Editor zu �berpr�fen
        Debug.Log("Spiel beenden wurde aufgerufen");

        // Beendet das Spiel, wenn es au�erhalb des Editors ausgef�hrt wird
        Application.Quit();
    }
}

