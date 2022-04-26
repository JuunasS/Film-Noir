using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogue : MonoBehaviour
{

    [HideInInspector] public Animator animator;
    public DialogueNode firstDialogue;
    public DialogueNode idleDialogue;

    public NPCName nameOfNPC;

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
    public void DisplayDialogue()
    {
        int index = (int)nameOfNPC;
        animator.SetBool("isTalking", true);
        switch (GameManager.manager.NPCList[index].dialogueProgress)   //k‰yd‰‰n l‰pi game managerissa olevaa listaa NPC:iden dialogien kulusta
        {
            case DialogueMode.FIRST_DIALOGUE:
                GameManager.manager.SetDialogue(firstDialogue);
                GameManager.manager.NPCList[index].dialogueProgress = DialogueMode.SECOND_DIALOGUE;
                break;

            case DialogueMode.SECOND_DIALOGUE:
                GameManager.manager.SetDialogue(idleDialogue);
                break;

            default:
                break;
        }
    }

}
