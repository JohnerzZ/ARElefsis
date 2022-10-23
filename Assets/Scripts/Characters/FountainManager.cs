using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainManager : MonoBehaviour
{

    public GameObject greeting,
                      question1Path1, question2Path1, question3Path1,
                      question1Path2, question2Path2, question3Path2,
                      answer1, answer2,
                      answer1Path1, answer2Path1,
                      answer1Path2, answer2Path2;


    private float time1 = 5f, time2 = 5f, time3 = 5f;

    private bool isPath1 = false, isPath2 = false;

    void Update()
    {
        if(CharacterAnimation.isGreeting) {
            StartCoroutine(GiveGreeting());
        }        
    }

    public void PressAnswerOne()
    {
        StartCoroutine(GiveQuestionOnePathOne());
        isPath1 = true;
    }

    public void PressAnswerTwo()
    {
        StartCoroutine(GiveQuestionOnePathTwo());
        isPath2 = true;
    }

    public void PressAnswerOnePathOne()
    {
        StartCoroutine(GiveQuestionTwoPathOne());
    }

    public void PressAnswerTwoPathOne()
    {
        StartCoroutine(GiveQuestionTwoPathTwo());
    }

    public void PressAnswerOnePathTwo()
    {
        StartCoroutine(GiveQuestionThreePathOne());
    }

    public void PressAnswerTwoPathTwo()
    {
        StartCoroutine(GiveQuestionTwoPathTwo());
    }

    void ShowAnswers()
    {
        if(isPath1)
        {
            answer1Path1.SetActive(true);
            answer2Path1.SetActive(true);
        }
        else if(isPath2)
        {
            answer1Path2.SetActive(true);
            answer2Path2.SetActive(true);
        }
        else
        {
            answer1.SetActive(true);
            answer2.SetActive(true);
        }
    }

    void HideAnswers()
    {
        answer1Path1.SetActive(false);
        answer2Path1.SetActive(false);
        answer1Path2.SetActive(false);
        answer2Path2.SetActive(false);
        answer1.SetActive(false);
        answer2.SetActive(false);
    }

    IEnumerator GiveGreeting()
    {
        greeting.SetActive(true);

        yield return new WaitForSeconds(5f);

        CharacterAnimation.isGreeting = false;

        greeting.SetActive(false);

        ShowAnswers();
    }

    IEnumerator GiveQuestionOnePathOne()
    {
        HideAnswers();

        CharacterAnimation.isTalking = true;

        question1Path1.SetActive(true);

        yield return new WaitForSeconds(time1);

        CharacterAnimation.isTalking = false;

        question1Path1.SetActive(false);

        ShowAnswers();
    }

    IEnumerator GiveQuestionTwoPathOne()
    {
        HideAnswers();

        CharacterAnimation.isTalking = true;

        question2Path1.SetActive(true);

        yield return new WaitForSeconds(time2);

        CharacterAnimation.isTalking = false;

        question2Path1.SetActive(false);

        ShowAnswers();
    }

    IEnumerator GiveQuestionThreePathOne()
    {
        HideAnswers();

        CharacterAnimation.isTalking = true;

        question3Path1.SetActive(true);

        yield return new WaitForSeconds(time3);

        CharacterAnimation.isTalking = false;

        question3Path1.SetActive(false);

        ShowAnswers();
    }

    IEnumerator GiveQuestionOnePathTwo()
    {
        HideAnswers();

        CharacterAnimation.isTalking = true;

        question1Path2.SetActive(true);

        yield return new WaitForSeconds(time1);

        CharacterAnimation.isTalking = false;

        question1Path2.SetActive(false);

        ShowAnswers();
    }

    IEnumerator GiveQuestionTwoPathTwo()
    {
        HideAnswers();

        CharacterAnimation.isTalking = true;

        question2Path2.SetActive(true);

        yield return new WaitForSeconds(time2);

        CharacterAnimation.isTalking = false;

        question2Path2.SetActive(false);

        ShowAnswers();
    }

    IEnumerator GiveQuestionThreePathTwo()
    {
        HideAnswers();

        CharacterAnimation.isTalking = true;

        question3Path2.SetActive(true);

        yield return new WaitForSeconds(time3);

        CharacterAnimation.isTalking = false;

        question3Path2.SetActive(false);

        ShowAnswers();
    }
}
