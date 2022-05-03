using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGetItem : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    public DialogueNode startingDialogue;
    public DialogueNode inBetweenDialogue;

    public InventoryObject givenItem;

    public NPCName nameOfNPC;
    public GameState newGameState;

    public bool changesGameState = false;

    bool hasBeenTalkedTo = false;
    int index;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnDestroy()
    {
        GameManager.manager.NPCList[index].dialogueProgress = DialogueMode.FIRST_DIALOGUE;
        if (changesGameState && hasBeenTalkedTo)
        {
            GameManager.manager.SetGameState(newGameState);
        }
        
    }

    public void DisplayDialogue()
    {
        index = (int)nameOfNPC;
        hasBeenTalkedTo = true;
        animator.SetBool("isTalking", true);
        switch (GameManager.manager.NPCList[index].dialogueProgress)
        {
            case DialogueMode.FIRST_DIALOGUE:
                GameManager.manager.SetDialogue(startingDialogue);
                GameManager.manager.AddItemToInventory(givenItem); //lis‰‰ annettavan esineen inventoryyn
                GameManager.manager.NPCList[index].dialogueProgress = DialogueMode.SECOND_DIALOGUE;
                break;

            case DialogueMode.SECOND_DIALOGUE:
                GameManager.manager.SetDialogue(inBetweenDialogue);
                break;

            default:
                break;
        }
    }

}
