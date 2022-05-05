using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : Interactable
{
    public DialogueNode start;

    public override void Interact() // tämä koodi on nyt tarkoitettu objekteille, joiden ainoa ominaisuus on dialogin tuottaminen
    {
        base.Interact();
        GameManager.manager.SetDialogue(start);
    }
}
