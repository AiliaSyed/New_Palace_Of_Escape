using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueMechanic : MonoBehaviour

{
    public GameObject AngelStatue;
    public GameObject AngelTarget;
    public GameObject AngelFakeTarget;

    public GameObject DevilStatue;
    public GameObject DevilTarget;
    public GameObject DevilFakeTarget;

    public GameObject NorthStatue;
    public GameObject NorthTarget;
    public GameObject NorthFakeTarget;

    public GameObject WestStatue;
    public GameObject WestTarget;
    public GameObject WestFakeTarget;

    public GameObject EastStatue;
    public GameObject EastTarget;
    public GameObject EastFakeTarget;

    public GameObject SouthStatue;
    public GameObject SouthTarget;
    public GameObject SouthFakeTarget;
    Damageable myScript;
    // Start is called before the first frame update
    void Start()
    {
        myScript = AngelFakeTarget.GetComponent<Damageable>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAtMistake()
    {
        myScript.Respawn = true;
        myScript.RespawnRoutine(5f);
        myScript.Respawn = false;
    }

    // Methode zum Aktivieren des GameObjects
    public void EnableObject(GameObject objectToToggle)
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(true);
        }
    }

    // Methode zum Deaktivieren des GameObjects
    public void DisableObject(GameObject objectToToggle)
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(false);
        }
    }


}
