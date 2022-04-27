using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChangeGState : MonoBehaviour
{

    [HideInInspector] public Animator animator;
    public DialogueNode firstDialogue;
    public DialogueNode idleDialogue;

    public NPCName nameOfNPC;
    public GameState newGameState;
    int index;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        index = (int)nameOfNPC;
    }

    private void Update()
    {
        if (!DialogueController.isConversationActive && animator.GetBool("isTalking") == true)
        {
            animator.SetBool("isTalking", false);
        }
    }
    private void OnDestroy()
    {
        GameManager.manager.NPCList[index].dialogueProgress = DialogueMode.FIRST_DIALOGUE;
        GameManager.manager.SetGameState(newGameState);
    }
    public void DisplayDialogue()
    {
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
