using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterScript : MonoBehaviour
{
    public GameObject textGreeting, textInformation, textQuest;

    private Animator animator;

    public static bool isGiveInfo = false, isGiveQuest = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(GiveGreeting());
    }


    void Update()
    {
        if(isGiveInfo && !isGiveQuest)
        {
            StartCoroutine(GiveInfo());
        }

        if (isGiveQuest && !isGiveInfo)
        {
            StartCoroutine(GiveQuest());
        }
    }

    IEnumerator GiveGreeting()
    {
        animator.SetBool("isGreeting", true);
        textInformation.SetActive(false);
        textQuest.SetActive(false);
        textGreeting.SetActive(true);

        yield return new WaitForSeconds(5f);

        animator.SetBool("isGreeting", false);
        textGreeting.SetActive(false);
    }

    IEnumerator GiveInfo()
    {
        isGiveInfo = false;

        animator.SetBool("isTalking", true);
        textGreeting.SetActive(false);
        textQuest.SetActive(false);
        textInformation.SetActive(true);

        yield return new WaitForSeconds(5f);

        animator.SetBool("isTalking", false);
        textInformation.SetActive(false);
    }

    IEnumerator GiveQuest()
    {
        isGiveQuest = false;

        animator.SetBool("isTalking", true);
        textGreeting.SetActive(false);
        textInformation.SetActive(false);
        textQuest.SetActive(true);

        yield return new WaitForSeconds(5f);

        animator.SetBool("isTalking", false);
        textQuest.SetActive(false);

    }
}
