using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : Interactable
{
    public DialogueNode start;

    public override void Interact() // t�m� koodi on nyt tarkoitettu objekteille, joiden ainoa ominaisuus on dialogin tuottaminen
    {
        base.Interact();
        GameManager.manager.SetDialogue(start);
    }

    /*
    private void OnMouseOver()
    {
        Debug.Log("Dialogue character clicked");
        if(Input.GetMouseButtonDown(0))
        {
            GameManager.manager.SetDialogue(start);
        }
    }
    */
}
