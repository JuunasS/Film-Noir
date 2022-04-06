using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dialog Object", menuName = "Dialog System")]
public class DialogueNode : ScriptableObject
{
    public event System.Action DialogComplete;

    public DialogCharacter Speaker;
    public string DialogueText;

    public List<ChoiceDialogueNode> ChoiceDialogs = new List<ChoiceDialogueNode>();

}
