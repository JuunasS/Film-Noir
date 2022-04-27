using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCcontroller))]
public class NPCInteract : Interactable
{
    [HideInInspector] public NPCcontroller instance;

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
