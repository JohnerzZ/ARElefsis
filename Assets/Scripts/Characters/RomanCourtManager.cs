using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RomanCourtManager : MonoBehaviour
{

    public GameObject greetingPanel,
                      playerPanel1, playerPanel2, playerPanel3,
                      characterPanel1, characterPanel2, characterPanel3;

    public float greetingTime,
                 option1Time, option2Time, option3Time;

    private bool isFirstTime = true;

    void Update()
    {
        if(CharacterAnimation.isGreeting && isFirstTime) {
            StartCoroutine(CharacterGreeting());
        }        
    }

    public void PlayerOptionOne()
    {
        StartCoroutine(CharacterOptionOne());
    }

    public void PlayerOptionTwo()
    {
        StartCoroutine(CharacterOptionTwo());
    }

    public void PlayerOptionThree()
    {
        StartCoroutine(CharacterOptionThree());
    }

    void ShowPlayerOptions()
    {
        playerPanel1.SetActive(true);
        playerPanel2.SetActive(true);
        playerPanel3.SetActive(true);
    }

    void HidePlayerOptions()
    {
        playerPanel1.SetActive(false);
        playerPanel2.SetActive(false);
        playerPanel3.SetActive(false);
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

    IEnumerator CharacterOptionOne()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPanel1.SetActive(true);

        yield return new WaitForSeconds(option1Time);

        characterPanel1.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }

    IEnumerator CharacterOptionTwo()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPanel2.SetActive(true);

        yield return new WaitForSeconds(option2Time);

        characterPanel2.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }

    IEnumerator CharacterOptionThree()
    {
        HidePlayerOptions();

        CharacterAnimation.isTalking = true;

        characterPanel3.SetActive(true);

        yield return new WaitForSeconds(option3Time);

        characterPanel3.SetActive(false);

        CharacterAnimation.isTalking = false;

        ShowPlayerOptions();
    }
}
