using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleLocked : Interactable
{
    public InventoryObject InventoryObject;
    public DialogueNode gotItemDialogue;
    public DialogueNode needItemDialogue;
    public bool changesGameState;

    public GameState newGameState;

    public InventoryObject opensCollectible;
    InventoryController inventory;

    public override void Interact()
    {
        base.Interact();
        inventory = FindObjectOfType<InventoryController>();
        if (inventory.InventoryContains(opensCollectible))
        {
            AddToInventory();
            Debug.Log("Item added to inventory");
            Destroy(gameObject);
        }
        else
        {
            GameManager.manager.SetDialogue(needItemDialogue);
        }
        
    }

    public void AddToInventory()
    {
        // Send Scriptable Object to  GameManager and from there to inventory controller
        GameManager.manager.AddItemToInventory(InventoryObject);
        GameManager.manager.SetDialogue(gotItemDialogue);
        if (changesGameState)
        {
            GameManager.manager.SetGameState(newGameState);
        }
    }
}

