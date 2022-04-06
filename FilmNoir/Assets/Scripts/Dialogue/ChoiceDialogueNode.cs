using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialog Object", menuName = "Dialog Choice")]
public class ChoiceDialogueNode : ScriptableObject
{
    public string Text;
    public DialogueNode NextNode;

    public void SetNextNode()
    {
        GameManager.manager.SetDialogue(NextNode);
    }
}
