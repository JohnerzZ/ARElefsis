using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FemaleAnimScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        bool isTalking = animator.GetBool("isTalking");

        if(Input.GetTouch(0).phase == TouchPhase.Began && !isTalking) {
            animator.SetBool("isTalking", true);

            DialogueManagerScript.instance.ShowDialogue();
        }

        if (Input.GetTouch(0).phase == TouchPhase.Began && isTalking)
        {
            animator.SetBool("isTalking", false);

            DialogueManagerScript.instance.HideDialogue();
        }
    }
}
