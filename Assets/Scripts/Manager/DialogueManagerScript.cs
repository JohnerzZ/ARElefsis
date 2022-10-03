using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerScript : MonoBehaviour
{
    public static DialogueManagerScript instance;

    public GameObject panel;
    public List<GameObject> textList;
    public List<AudioSource> audioList;
    private Animator animator;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        animator = panel.GetComponent<Animator>();
    }

    
    public void ShowDialogue()
    {
        animator.Play("PanelFadeIn");
        textList[0].SetActive(true);
        audioList[0].Play();
    }

    public void HideDialogue()
    {
        animator.Play("PanelFadeOut");
        textList[0].SetActive(false);
        audioList[0].Stop();
    }
}
