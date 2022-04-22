using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour
{
    public Animator animator;
    public DialogueNode startingDialogue;
    public DialogueNode secondDialogue;
    public DialogueNode inBetweenDialogue;
    public DialogueNode thirdDialogue;

    public InventoryObject wantedObject;
    InventoryController inventory;

    public NPCName nameOfNPC;

    public bool hasMoreToSay;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        inventory = FindObjectOfType<InventoryController>();
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
        switch (GameManager.manager.NPCList[index].dialogueProgress)   //k�yd��n l�pi game managerissa olevaa listaa NPC:iden dialogien kulusta
        {
            case DialogueMode.FIRST_DIALOGUE:
                GameManager.manager.SetDialogue(startingDialogue);
                GameManager.manager.NPCList[index].dialogueProgress = DialogueMode.SECOND_DIALOGUE;
                break;

            case DialogueMode.SECOND_DIALOGUE:
                if(inventory.InventoryContains(wantedObject))
                {
                    GameManager.manager.SetDialogue(secondDialogue);
                    if (hasMoreToSay)
                    {
                        GameManager.manager.NPCList[index].dialogueProgress = DialogueMode.THIRD_DIALOGUE;
                    }
                }
                else
                    GameManager.manager.SetDialogue(inBetweenDialogue);
                break;

            case DialogueMode.THIRD_DIALOGUE:
                GameManager.manager.SetDialogue(thirdDialogue);
                break;

            default:
                break;
        }
    }

}

// toimii helpottamaan dialogien sis�ll�n muistamista
public enum DialogueMode
{
    FIRST_DIALOGUE,
    SECOND_DIALOGUE,
    THIRD_DIALOGUE
}


//Toimii indeksin� kun hy�dynnet��n game managerissa olevaa listaa t�ynn� NPC:iden dialogin kulkua
public enum NPCName // t�nne merkitt�v� eri NPC:iden nimet, ja sitten pidett�v� ne gameManagerissa samassa j�rjestyksess�
{
    PAWNSHOPNPC = 0,
    TESTNPC
}

// luokka josta tehd��n olioita joita tallennetaan game managerissa olevaan listaan
public class NPCInfo
{
    public string name;
    public DialogueMode dialogueProgress;

    public NPCInfo(string newName, DialogueMode newDialogueProgress)
    {
        name = newName;
        dialogueProgress = newDialogueProgress;
    }
}
