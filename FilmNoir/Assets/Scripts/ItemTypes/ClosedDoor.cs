using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosedDoor : Interactable
{

    public string levelToLoad;
    public bool doesGameStateChange = false;

    public GameState newGameState;
    int discussionPoint = 0;

    public DialogueNode landLadyDialogue;
    public DialogueNode youHavePinDialogue;
    public DialogueNode dontHavePinDialogue;

    public InventoryObject wantedObject;
    InventoryController inventory;

    public GameObject doorClosedItem;
    public GameObject doorOpenItem;

    public override void Interact()
    {
        base.Interact();
        inventory = FindObjectOfType<InventoryController>();
        Debug.Log("p‰‰stiin t‰nne");
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        switch (discussionPoint)
        {
            case 0:
                GameManager.manager.SetDialogue(landLadyDialogue);
                discussionPoint++;
                break;

            case 1:
                if (inventory.InventoryContains(wantedObject))
                {
                    GameManager.manager.SetDialogue(youHavePinDialogue);
                    doorClosedItem.SetActive(false);
                    doorOpenItem.SetActive(true);
                    discussionPoint++;
                }
                else
                    GameManager.manager.SetDialogue(dontHavePinDialogue);
                break;

            case 2:
                if (doesGameStateChange && newGameState != null)
                {
                    GameManager.manager.SetGameState(newGameState);
                }
                SceneManager.LoadScene(levelToLoad);
                break;
            default:
                break;
        }
    }
}
