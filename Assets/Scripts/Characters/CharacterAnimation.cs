using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;

    public static bool isGreeting = false, isTalking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        isGreeting = true;
    }

    void Update()
    {
        if(isGreeting)
        {
            animator.SetBool("isGreeting", true);
        }
        else
        {
            animator.SetBool("isGreeting", false);
        }

        if(isTalking)
        {
            animator.SetBool("isTalking", true);
        }
        else
        {
            animator.SetBool("isTalking", false);
        }
    }
}
