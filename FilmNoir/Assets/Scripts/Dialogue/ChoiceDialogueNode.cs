using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialog Object", menuName = "Dialog/Dialog Choice")]
public class ChoiceDialogueNode : ScriptableObject
{
    public string Text;
    public DialogueNode NextNode;
    public bool IsExit;
    public string JoiningNPC;

    public bool GivesItem;
    public InventoryObject InventoryItem;

    public void SetNextNode()
    {
        if(JoiningNPC != "")
        {
            GameManager.manager.NpcJoinConversation(JoiningNPC, NextNode);
        }
        else
        {
            GameManager.manager.SetDialogue(NextNode);
        }
        if (GivesItem)
        {
            GameManager.manager.AddItemToInventory(InventoryItem);
        }
    }
}
