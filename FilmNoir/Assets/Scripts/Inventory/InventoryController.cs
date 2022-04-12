using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject InventoryPanel; // Contains all panels
    public List<GameObject> Panels = new List<GameObject>(); // 16 Panels
    public List<InventoryObject> PlayerInventory = new List<InventoryObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInventory()
    {
        if (InventoryPanel.activeInHierarchy)
        {
            Debug.Log("Inventory hidden");
            InventoryPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Inventory revealed");
            InventoryPanel.SetActive(true);
        }
    }

    public void AddItem(InventoryObject invObject)
    {
        PlayerInventory.Add(invObject);
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < PlayerInventory.Count; i++)
        {
            Panels[i].GetComponentInChildren<Image>().sprite = PlayerInventory[i].sprite;
        }
    }
}
