using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanCourtManager : MonoBehaviour
{

    public GameObject greeting,
                      question1, question2, question3,
                      answer1, answer2, answer3;

    private float time1 = 5f, time2 = 5f, time3 = 5f;

    void Update()
    {
        if(CharacterAnimation.isGreeting) {
            StartCoroutine(GiveGreeting());
        }        
    }

    public void PressQuestionOne()
    {
        StartCoroutine(GiveAnswerOne());
    }

    public void PressQuestionTwo()
    {
        StartCoroutine(GiveAnswerTwo());
    }

    public void PressQuestionThree()
    {
        StartCoroutine(GiveAnswerThree());
    }

    void ShowQuestions()
    {
        question1.SetActive(true);
        question2.SetActive(true);
        question3.SetActive(true);
    }

    void HideQuestions()
    {
        question1.SetActive(false);
        question2.SetActive(false);
        question3.SetActive(false);
    }

    IEnumerator GiveGreeting()
    {
        greeting.SetActive(true);

        yield return new WaitForSeconds(5f);

        CharacterAnimation.isGreeting = false;

        greeting.SetActive(false);

        ShowQuestions();
    }

    IEnumerator GiveAnswerOne()
    {
        HideQuestions();

        CharacterAnimation.isTalking = true;

        answer1.SetActive(true);

        yield return new WaitForSeconds(time1);

        CharacterAnimation.isTalking = false;

        answer1.SetActive(false);

        ShowQuestions();
    }

    IEnumerator GiveAnswerTwo()
    {
        HideQuestions();

        CharacterAnimation.isTalking = true;

        answer2.SetActive(true);

        yield return new WaitForSeconds(time2);

        CharacterAnimation.isTalking = false;

        answer2.SetActive(false);

        ShowQuestions();
    }

    IEnumerator GiveAnswerThree()
    {
        HideQuestions();

        CharacterAnimation.isTalking = true;

        answer3.SetActive(true);

        yield return new WaitForSeconds(time3);

        CharacterAnimation.isTalking = false;

        answer3.SetActive(false);

        ShowQuestions();
    }
}
