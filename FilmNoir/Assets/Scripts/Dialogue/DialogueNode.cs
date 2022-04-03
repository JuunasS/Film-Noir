using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Dialog Object", menuName = "Dialog System")]
public class DialogueNode : ScriptableObject
{
    public event System.Action DialogComplete;

    public Queue<string> DialogueText;

    public bool IsLoopable;
    public bool IsOrdered;

    public DialogueNode NextDialogue;


}
