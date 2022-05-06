using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialog Object", menuName = "Dialog/Dialog Choice")]
public class ChoiceDialogueNode : ScriptableObject
{
    [TextArea(5, 10)]
    public string Text;
    public DialogueNode NextNode;
    public bool IsExit;
    public string JoiningNPC;
    public string ExitingNPC;


    public bool GivesItem;
    public InventoryObject InventoryItem;

    public void SetNextNode()
    {
        try
        {
            if (GivesItem)
            {
                GameManager.manager.AddItemToInventory(InventoryItem);
            }
            if (ExitingNPC != "")
            {
                GameManager.manager.NpcExitConversation(ExitingNPC, NextNode);
            }
            else if (JoiningNPC != "")
            {
                GameManager.manager.NpcJoinConversation(JoiningNPC, NextNode);
            }
            else
            {
                Debug.Log("Choice node setting dialogue: " + NextNode);
                GameManager.manager.SetDialogue(NextNode);

            }

        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
            Debug.LogError("Something is missing in dialogue. Please check that all dialogueChoices and dialogueNodes are all filled as needed.");
        }
    }

    public void ExitDialogue()
    {
        if (ExitingNPC != "")
        {
            GameManager.manager.NpcExitConversation(ExitingNPC, NextNode);
        }
        if (GivesItem)
        {
            GameManager.manager.AddItemToInventory(InventoryItem);
        }
        GameManager.manager.ExitDialogue();
    }

}
