using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Inventory Object", menuName = "Inventory/Item")]
public class InventoryObject : ScriptableObject
{
    public Sprite sprite;

    public string ItemName;
    [TextArea(5, 10)]
    public string Description;
    public DialogCharacter Connection;
}
