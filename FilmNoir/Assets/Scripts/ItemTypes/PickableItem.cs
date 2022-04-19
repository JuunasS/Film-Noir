using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : Interactable
{
    public InventoryObject InventoryObject;
    public DialogueNode start;

    public override void Interact()
    {
        base.Interact();
        AddToInventory();
        Debug.Log("Item added to inventory");
        Destroy(gameObject);
    }

    public void AddToInventory()
    {
        // Send Scriptable Object to  GameManager and from there to inventory controller
        GameManager.manager.AddItemToInventory(InventoryObject);
        GameManager.manager.SetDialogue(start);
    }
}
