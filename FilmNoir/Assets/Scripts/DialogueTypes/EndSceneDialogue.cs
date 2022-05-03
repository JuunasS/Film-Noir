using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneDialogue : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    public DialogueNode barbaraSurvivesDialogue;
    public DialogueNode barbaraDiesDialogue;

    public InventoryObject wantedObject;
    InventoryController inventory;

    private bool doesBarbaraDie = false;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if(!DialogueController.isConversationActive && doesBarbaraDie)
        {
            Debug.Log("Barbara kuolee"); //t�h�n voidaan laittaa lopputeksti ja whatever
        }
        if(!DialogueController.isConversationActive && !doesBarbaraDie)
        {
            Debug.Log("Barbara ei kuole");
        }
    }

    public void DisplayDialogue()
    {
        animator.SetBool("isTalking", true);
        if (inventory.InventoryContains(wantedObject))
        {
            GameManager.manager.SetDialogue(barbaraSurvivesDialogue);
        }
        else
        {
            GameManager.manager.SetDialogue(barbaraDiesDialogue);
            doesBarbaraDie = true;
        } 
    }

}
