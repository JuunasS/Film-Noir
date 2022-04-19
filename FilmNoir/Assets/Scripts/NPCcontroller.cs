using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour
{
    public Animator animator;
    public static bool dialogueStarted = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(DialogueController.isConversationActive)
        {
            animator.SetBool("isTalking", true);
        }
        if (!DialogueController.isConversationActive)
        {
            dialogueStarted = false;
            animator.SetBool("isTalking", false);
        }
    }
}
