using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject InventoryPanel; // Contains all panels
    public List<GameObject> Panels = new List<GameObject>(); // 16 Panels
    public List<InventoryObject> PlayerInventory = new List<InventoryObject>();

    public GameObject DescriptionPanel;
    public Text DescriptionItemName;
    public GameObject ImagePanel;
    public GameObject DescriptionText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.manager.GetInventoryCanvas() != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool InventoryContains(InventoryObject obj)
    {
        foreach(InventoryObject invObj in PlayerInventory)
        {
            if(obj == invObj)
            {
                return true;    
            }
        }
        return false;
    }

    public void ToggleInventory()
    {
        if (InventoryPanel.activeInHierarchy)
        {
            Debug.Log("Inventory hidden");
            InventoryPanel.SetActive(false);
            PlayerController.canMove = true;
        }
        else
        {
            Debug.Log("Inventory revealed");
            InventoryPanel.SetActive(true);
            PlayerController.canMove = false; //pys‰ytt‰‰ pelaajan liikkeen inventoryn avaamisen ajaksi
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
            Panels[i].GetComponent<InventoryPanel>().SetInventoryObject(PlayerInventory[i]);
        }
    }


    public void DisplayDescription(string name, string description, Sprite image)
    {
        DescriptionPanel.SetActive(true);

        DescriptionItemName.text = name;
        ImagePanel.GetComponent<Image>().sprite = image;
        DescriptionText.GetComponentInChildren<Text>().text = description;
    }

    public void DisableDescription()
    {
        DescriptionPanel.SetActive(false);
    }
}
