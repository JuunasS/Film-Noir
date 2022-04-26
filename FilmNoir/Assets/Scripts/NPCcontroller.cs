using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontroller : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    /*
    public DialogueNode startingDialogue;
    public DialogueNode secondDialogue;
    public DialogueNode inBetweenDialogue;
    public DialogueNode thirdDialogue;

    public InventoryObject wantedObject;
    InventoryController inventory;

    */
    [HideInInspector]public SimpleDialogue simpleDialogue;
    [HideInInspector] public DialogueNeedsItem dialogWithItem;

    public NPCName nameOfNPC;
    public DialogueStyle styleOfDialogue;

    public bool hasMoreToSay;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        //inventory = FindObjectOfType<InventoryController>();
    }

    private void Update()
    {
        if (!DialogueController.isConversationActive && animator.GetBool("isTalking") == true)
        {
            animator.SetBool("isTalking", false);
        }
    }
    public void ChooseDialogue()
    {
        if(styleOfDialogue == DialogueStyle.SIMPLE_DIALOGUE)
        {
            simpleDialogue = gameObject.GetComponent<SimpleDialogue>();
            simpleDialogue.DisplayDialogue();
        }
        else if (styleOfDialogue == DialogueStyle.NEEDS_ITEM)
        {
            dialogWithItem = gameObject.GetComponent<DialogueNeedsItem>();
            dialogWithItem.DisplayDialogue();
        }
        /*
        int index = (int)nameOfNPC;
        animator.SetBool("isTalking", true);
        switch (GameManager.manager.NPCList[index].dialogueProgress)   //käydään läpi game managerissa olevaa listaa NPC:iden dialogien kulusta
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
        */
    }

}

// toimii helpottamaan dialogien sisällön muistamista
public enum DialogueMode
{
    FIRST_DIALOGUE,
    SECOND_DIALOGUE,
    THIRD_DIALOGUE
}

public enum DialogueStyle
{
    SIMPLE_DIALOGUE,
    NEEDS_ITEM
}


//Toimii indeksinä kun hyödynnetään game managerissa olevaa listaa täynnä NPC:iden dialogin kulkua
public enum NPCName // tänne merkittävä eri NPC:iden nimet, ja sitten pidettävä ne gameManagerissa samassa järjestyksessä
{
    PAWNSHOPNPC = 0,
    BARBARA,
    SINGER,
    GANGSTER,
    HAIRDRESSER,
    ANTAGONIST,
    BARTENDER
}

// luokka josta tehdään olioita joita tallennetaan game managerissa olevaan listaan
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
