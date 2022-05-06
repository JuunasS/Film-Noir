using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogue : MonoBehaviour
{

    [HideInInspector] public Animator animator;
    public DialogueNode firstDialogue;
    public DialogueNode idleDialogue;

    public NPCName nameOfNPC;
    public GameState newGameState;

    public bool changesGameState;
    public bool updatedGameState;

    bool hasBeenTalkedTo = false;
    int index;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (changesGameState && hasBeenTalkedTo && !updatedGameState)
        {
            GameManager.manager.SetGameState(newGameState);
            updatedGameState = true;
        }
    }

    private void OnDestroy()
    {
        GameManager.manager.NPCList[index].dialogueProgress = DialogueMode.FIRST_DIALOGUE;
    }

    public void DisplayDialogue()
    {
        index = (int)nameOfNPC;
        hasBeenTalkedTo = true;
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

    public void UpdateGameState()
    {
        if (changesGameState && hasBeenTalkedTo)
        {
            GameManager.manager.SetGameState(newGameState);
        }
    }

}
