using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject[] trafficLights; // Array der Ampel-GameObjects
    private PlayerSequenceRecorder playerSequenceRecorder;

    // Starte die Ampelzyklen


    private void Awake()
    {
        // Holt die Referenz auf das PlayerSequenceRecorder-Skript
        playerSequenceRecorder = FindObjectOfType<PlayerSequenceRecorder>();
    }
    public void StartAgain()
    {
        StartCoroutine(Start());
    }
    private IEnumerator Start()
    {
        while (true)
        {
            // Führe 4 Wechselzyklen durch
            for (int i = 0; i < 5; i++)
            {
                foreach (GameObject light in trafficLights)
                {
                    if (!light.GetComponent<AmpelStatus>().buttonpressed)
                    {
                        // Entscheide zufällig, ob die Ampel rot oder grün sein soll
                        int randomState = Random.Range(1, 3); // Gibt 1 oder 2 zurück
                        bool isRed = light.GetComponent<AmpelStatus>().isRed; // Zugriff auf den isRed Status der Ampel

                        if (randomState == 1)
                        {
                            StartCoroutine(SetToRed(light));
                            light.GetComponent<AmpelStatus>().isRed = true; // Setze isRed auf true
                        }
                        else
                        {
                            StartCoroutine(SwitchToGreen(light));
                            light.GetComponent<AmpelStatus>().isRed = false; // Setze isRed auf false
                        }
                    }

                }
                // Warte 10 Sekunden zwischen den Phasen
                yield return new WaitForSeconds(10);
            }
            if (!CheckButtonPressedAndSkip()) {

                foreach (GameObject light in trafficLights)
                {
                    light.GetComponent<AmpelStatus>().redPhase = true;
                }

                Debug.Log("Rote Phase beginnt");
                foreach (GameObject light in trafficLights)
                {
                    StartCoroutine(SetToRed(light));
                    light.GetComponent<AmpelStatus>().isRed = true; // Setze isRed auf true
                    light.GetComponent<TrafficLightSoundController>().EnableSound();
                }

                playerSequenceRecorder.StartRedPhase();
                yield return new WaitForSeconds(60);

                foreach (GameObject light in trafficLights)
                {
                    light.GetComponent<TrafficLightSoundController>().DisableSound();
                }

                playerSequenceRecorder.EndRedPhase();
                foreach (GameObject light in trafficLights)
                {
                    light.GetComponent<AmpelStatus>().redPhase = false;
                }
                Debug.Log("Rote Phase endet");
            }

        }
    }

    bool CheckButtonPressedAndSkip()
    {
        foreach (GameObject trafficLight in trafficLights)
        {
            if (trafficLight.GetComponent<AmpelStatus>().buttonpressed)
            {
                Debug.Log("Button is Pressed, keine rote Phase");
                return true;
            }
        }
        return false;
    }

    private IEnumerator SwitchToGreen(GameObject trafficLight)
    {
        // Finde die Lichter als Child-Objekte
        GameObject redLight = trafficLight.transform.Find("red_light").gameObject;
        GameObject yellowLight = trafficLight.transform.Find("yellow_light").gameObject;
        GameObject greenLight = trafficLight.transform.Find("green_light").gameObject;

        // Schalte von Rot zu Grün über Gelb
        if (redLight.activeSelf)
        {
            // Aktiviere Gelb für 2 Sekunden zusammen mit Rot
            yellowLight.SetActive(true);
            yield return new WaitForSeconds(2);
        }

        // Deaktiviere Rot und Gelb, aktiviere Grün
        redLight.SetActive(false);
        yellowLight.SetActive(false);
        greenLight.SetActive(true);
    }

    private IEnumerator SetToRed(GameObject trafficLight)
    {
        // Finde die Lichter als Child-Objekte
        GameObject redLight = trafficLight.transform.Find("red_light").gameObject;
        GameObject yellowLight = trafficLight.transform.Find("yellow_light").gameObject;
        GameObject greenLight = trafficLight.transform.Find("green_light").gameObject;

        if(greenLight.activeSelf)
        {
            greenLight.SetActive(false);
            yellowLight.SetActive(true);
            yield return new WaitForSeconds(2);

        }

        // Deaktiviere Gelb und Grün, aktiviere Rot
        yellowLight.SetActive(false);
        greenLight.SetActive(false);
        redLight.SetActive(true);
    }
}
