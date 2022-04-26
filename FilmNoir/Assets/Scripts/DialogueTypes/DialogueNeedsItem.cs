using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNeedsItem : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    public DialogueNode startingDialogue;
    public DialogueNode secondDialogue;
    public DialogueNode inBetweenDialogue;

    public InventoryObject wantedObject;
    InventoryController inventory;

    public NPCName nameOfNPC;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
    }

    public void DisplayDialogue()
    {
        int index = (int)nameOfNPC;
        animator.SetBool("isTalking", true);
        switch (GameManager.manager.NPCList[index].dialogueProgress)   //k‰yd‰‰n l‰pi game managerissa olevaa listaa NPC:iden dialogien kulusta
        {
            case DialogueMode.FIRST_DIALOGUE:
                GameManager.manager.SetDialogue(startingDialogue);
                GameManager.manager.NPCList[index].dialogueProgress = DialogueMode.SECOND_DIALOGUE;
                break;

            case DialogueMode.SECOND_DIALOGUE:
                if (inventory.InventoryContains(wantedObject))
                {
                    GameManager.manager.SetDialogue(secondDialogue);
                }
                else
                    GameManager.manager.SetDialogue(inBetweenDialogue);
                break;

            default:
                break;
        }
    }

}
