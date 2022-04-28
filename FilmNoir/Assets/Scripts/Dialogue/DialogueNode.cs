using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialog Object", menuName = "Dialog/Dialog Node")]
public class DialogueNode : ScriptableObject
{
    public event System.Action DialogComplete;

    public DialogCharacter Speaker;
    [TextArea(5, 10)]
    public string DialogueText;

    public List<ChoiceDialogueNode> ChoiceDialogs = new List<ChoiceDialogueNode>();

}
