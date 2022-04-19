using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour
{
    public Animator animator;
    public DialogueNode startingDialogue;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!DialogueController.isConversationActive && animator.GetBool("isTalking") == true)
        {
            animator.SetBool("isTalking", false);
        }
    }
    public void haveDialogue()
    {
        animator.SetBool("isTalking", true);
        GameManager.manager.SetDialogue(startingDialogue);
    }

}
