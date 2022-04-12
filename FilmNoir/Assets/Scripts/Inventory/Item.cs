using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public InventoryObject InventoryObject;

    public void AddToInventory()
    {
        // Send Scriptable Object to  GameManager and from there to inventory controller
        GameManager.manager.AddItemToInventory(InventoryObject);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddToInventory();
            Debug.Log("Item added to inventory");
            Destroy(gameObject);
        }
    }
}
