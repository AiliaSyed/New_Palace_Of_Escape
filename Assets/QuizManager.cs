using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public bool OrionQuiz = false;
    public bool GreatBearQuiz = false;

    public GameObject OrionQuestion1;
    public GameObject OrionQuestion2;
    public GameObject OrionQuestion3;
    public GameObject OrionQuizComplete;

    public GameObject OrionWrongAnswerText;

    public GameObject GreatBearQuestion1;
    public GameObject GreatBearQuestion2;
    public GameObject GreatBearQuestion3;
    public GameObject GreatBearQuizComplete;

    public GameObject GreatBearWrongAnswerText;

    public GameObject Door;
    public GameObject Wall;


    public InputField[] PlayerAnswers;
    public string[] OrionAnswers;
    public string[] GreatBearAnswers;

    public void Start()
    {
        Debug.Log("Gestartet");
        OrionQuestion2.SetActive(false);
        OrionQuestion3.SetActive(false);
        OrionQuizComplete.SetActive(false);
        OrionWrongAnswerText.SetActive(false);

        GreatBearQuestion2.SetActive(false);
        GreatBearQuestion3.SetActive(false);
        GreatBearQuizComplete.SetActive(false);
        GreatBearWrongAnswerText.SetActive(false);

        Door.SetActive(false);
    }

    public void Update()
    {
        if (GreatBearQuiz && OrionQuiz)
        {
            OpenDoor();
        }
    }


    private void OpenDoor()
    {
        Wall.SetActive(false);
        Door.SetActive(true);
    }
    public void CheckOrionQuestion1()
    {
        if (PlayerAnswers[0].text == OrionAnswers[0] || PlayerAnswers[0].text == OrionAnswers[1])
        {
            OrionWrongAnswerText.SetActive(false);
            OrionQuestion1.SetActive(false);
            OrionQuestion2.SetActive(true);
            Debug.Log("Frage war richtig");
        }
        else
        {
            Debug.Log("Frage war falsch");
        }
    }

    public void CheckOrionQuestion2()
    {
        if (PlayerAnswers[1].text == OrionAnswers[2] || PlayerAnswers[1].text == OrionAnswers[3])
        {
            OrionWrongAnswerText.SetActive(false);
            OrionQuestion2.SetActive(false);
            OrionQuestion3.SetActive(true);
        }
        else
        {
            Debug.Log("Frage war falsch");
        }

    }

    public void CheckOrionQuestion3()
    {
        if (PlayerAnswers[2].text == OrionAnswers[4] || PlayerAnswers[2].text == OrionAnswers[5])
        {
            OrionWrongAnswerText.SetActive(false);
            OrionQuestion3.SetActive(false);
            OrionQuizComplete.SetActive(true);
            OrionQuiz = true;
        }
        else
        {
            Debug.Log("Frage war falsch");
        }
    }

    public void CheckGreatBearQuestion1()
    {
        if (PlayerAnswers[3].text == GreatBearAnswers[0] || PlayerAnswers[3].text == GreatBearAnswers[1])
        {
            GreatBearWrongAnswerText.SetActive(false);
            GreatBearQuestion1.SetActive(false);
            GreatBearQuestion2.SetActive(true);
            Debug.Log("Frage war richtig");
        }
        else
        {
            Debug.Log("Frage war falsch");
        }
    }

    public void CheckGreatBearQuestion2()
    {
        if (PlayerAnswers[4].text == GreatBearAnswers[2] || PlayerAnswers[4].text == GreatBearAnswers[3] || PlayerAnswers[4].text == GreatBearAnswers[4] || PlayerAnswers[4].text == GreatBearAnswers[5])
        {
            GreatBearWrongAnswerText.SetActive(false);
            GreatBearQuestion2.SetActive(false);
            GreatBearQuestion3.SetActive(true);
        }
        else
        {
            Debug.Log("Frage war falsch");
        }
    }

    public void CheckGreatBearQuestion3()
    {
        if (PlayerAnswers[5].text == GreatBearAnswers[6] || PlayerAnswers[5].text == GreatBearAnswers[7])
        {
            GreatBearWrongAnswerText.SetActive(false);
            GreatBearQuestion3.SetActive(false);
            GreatBearQuizComplete.SetActive(true);
            GreatBearQuiz = true;
        }
        else
        {
            Debug.Log("Frage war falsch");
        }
    }
}
