using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainManager : MonoBehaviour
{

    public GameObject greetingPanel,
                      characterPath1Panel1, characterPath1Panel2, characterPath1Panel3,
                      characterPath2Panel1, characterPath2Panel2, characterPath2Panel3,
                      playerPath1Panel1, playerPath1Panel2, playerPath1Panel3,
                      playerPath2Panel1, playerPath2Panel2, playerPath2Panel3;


    public float greetingTime,
                 option1Path1Time, option2Path1Time, option3Path1Time,
                 option1Path2Time, option2Path2Time, option3Path2Time;

    private bool isPath1 = false, isPath2 = false;

    private bool isFirstTime = true;

    void Update()
    {
        if(CharacterAnimation.isGreeting && isFirstTime) {
            StartCoroutine(CharacterGreeting());
        }        
    }

    public void PlayerOptionOnePathOne()
    {
        StartCoroutine(CharacterOptionOnePathOne());
        isPath1 = true;
    }

    public void PlayerOptionTwoPathOne()
    {
        StartCoroutine(CharacterOptionTwoPathOne());
    }

    public void PlayerOptionThreePathOne()
    {
        StartCoroutine(CharacterOptionThreePathOne());
    }

    public void PlayerOptionOnePathTwo()
    {
        StartCoroutine(CharacterOptionOnePathTwo());
        isPath2 = true;
    }

    public void PlayerOptionTwoPathTwo()
    {
        StartCoroutine(CharacterOptionTwoPathTwo());
    }

    public void PlayerOptionThreePathTwo()
    {
        StartCoroutine(CharacterOptionThreePathTwo());
    }

    void ShowPlayerOptions()
    {
        if(isPath1)
        {
            playerPath1Panel2.SetActive(true);
            playerPath1Panel3.SetActive(true);
        }
        else if(isPath2)
        {
            playerPath2Panel2.SetActive(true);
            playerPath2Panel3.SetActive(true);
        }
        else
        {
            playerPath1Panel1.SetActive(true);
            playerPath2Panel1.SetActive(true);
        }
    }

    void HidePlayerOptions()
    {
        playerPath1Panel1.SetActive(false);
        playerPath1Panel2.SetActive(false);
        playerPath1Panel3.SetActive(false);
        playerPath2Panel1.SetActive(false);
        playerPath2Panel2.SetActive(false);
        playerPath2Panel3.SetActive(false);
    }

    IEnumerator CharacterGreeting()
    {
        isFirstTime = false;

        greetingPanel.SetActive(true);

        yield return new WaitForSeconds(greetingTime);

        greetingPanel.SetActive(false);

        CharacterAnimation.isGreeting = false;

        ShowPlayerOptions();
    }

    IEnumerator CharacterOptionOnePathOne()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPath1Panel1.SetActive(true);

        yield return new WaitForSeconds(option1Path1Time);

        characterPath1Panel1.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }

    IEnumerator CharacterOptionTwoPathOne()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPath1Panel2.SetActive(true);

        yield return new WaitForSeconds(option2Path1Time);

        characterPath1Panel2.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }

    IEnumerator CharacterOptionThreePathOne()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPath1Panel3.SetActive(true);

        yield return new WaitForSeconds(option3Path1Time);

        characterPath1Panel3.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }

    IEnumerator CharacterOptionOnePathTwo()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPath2Panel1.SetActive(true);

        yield return new WaitForSeconds(option1Path2Time);

        characterPath2Panel1.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }

    IEnumerator CharacterOptionTwoPathTwo()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPath2Panel2.SetActive(true);

        yield return new WaitForSeconds(option2Path2Time);

        characterPath2Panel2.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }

    IEnumerator CharacterOptionThreePathTwo()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPath2Panel3.SetActive(true);

        yield return new WaitForSeconds(option3Path2Time);

        characterPath2Panel3.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }
}
