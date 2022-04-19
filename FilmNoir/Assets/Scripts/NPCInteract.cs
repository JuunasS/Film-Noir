using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : Interactable
{
    public DialogueNode start;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Juteltu NPC:lle!");
        haveDialogue();

    }

    public void haveDialogue()
    {
        NPCcontroller.dialogueStarted = true;
        GameManager.manager.SetDialogue(start);
    }

}
