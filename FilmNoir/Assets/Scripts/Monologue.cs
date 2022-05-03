using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monologue : MonoBehaviour
{
    public bool isThereMonologue;
    public DialogueNode monologueNode;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.manager.SetDialogue(monologueNode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
