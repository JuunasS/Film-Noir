using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : Interactable
{
    public NPCcontroller instance;

    private void Start()
    {
        instance = gameObject.GetComponent<NPCcontroller>();
    }
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Juteltu NPC:lle!");
        instance.ChooseDialogue();
    }
}
