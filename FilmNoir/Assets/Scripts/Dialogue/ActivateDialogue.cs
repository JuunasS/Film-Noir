using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : MonoBehaviour
{
    public DialogueNode start;

    private void OnMouseOver()
    {
        Debug.Log("Dialogue character clicked");
        if(Input.GetMouseButtonDown(0))
        {
            GameManager.manager.SetDialogue(start);
        }
    }
}
