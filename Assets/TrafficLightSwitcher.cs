using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightSwitcher : MonoBehaviour
{
    public GameObject[] trafficLights; // Array der Ampel-GameObjects
    GameObject redLight;
    GameObject yellowLight;
    GameObject greenLight;

    public void StartSwitching() 
    {
        Debug.Log("Switch wird gestartet");
        StartCoroutine(SwitchTrafficLights());
    }

    private IEnumerator SwitchTrafficLights()
    {
        if (!checkRedPhase())
        {
            Debug.Log("Ampel wird geschaltet");
            foreach (GameObject trafficLight in trafficLights)
            {
                AmpelStatus ampelStatus = trafficLight.GetComponent<AmpelStatus>();
                redLight = trafficLight.transform.Find("red_light").gameObject;
                yellowLight = trafficLight.transform.Find("yellow_light").gameObject;
                greenLight = trafficLight.transform.Find("green_light").gameObject;
                if (ampelStatus != null)
                {
                    if (ampelStatus.isRed)
                    {
                        // Aktiviere Gelb für 2 Sekunden zusammen mit Rot
                        yellowLight.SetActive(true);
                        yield return new WaitForSeconds(1);
                        redLight.SetActive(false);
                        yellowLight.SetActive(false);
                        greenLight.SetActive(true);
                    }
                    else
                    {
                        redLight.SetActive(false);
                        yellowLight.SetActive(false);
                        greenLight.SetActive(true);

                    }
                    ampelStatus.buttonpressed = true;
                    
                }
            }
            // Warte 15 Sekunden
            yield return new WaitForSeconds(15);
            foreach (GameObject trafficLight in trafficLights)
            {
                AmpelStatus ampelStatus = trafficLight.GetComponent<AmpelStatus>();
                ampelStatus.buttonpressed = false;
            }
                
        }
    }

    bool checkRedPhase()
    {
        foreach (GameObject trafficLight in trafficLights) 
        {
            if (trafficLight.GetComponent<AmpelStatus>().redPhase)
            {
                Debug.Log("Ampel ist in rote Phase");
                return true;
            }
        }
        Debug.Log("Ampel ist nicht in rote Phase");
        return false;
    }
}
