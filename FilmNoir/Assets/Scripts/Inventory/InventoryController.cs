using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject InventoryPanel; // Contains all panels
    public List<GameObject> Panels = new List<GameObject>(); // 16 Panels

    public GameObject DescriptionPanel;
    public Text DescriptionItemName;
    public GameObject ImagePanel;
    public GameObject DescriptionText;

    public AudioSource InvOpenAudio;

    // Start is called before the first frame update
    void Start()
    {
        InvOpenAudio = GetComponent<AudioSource>();
        Debug.Log("InventoryController Start");
        if (GameManager.manager.GetInventoryCanvas() != null)
        {
            Debug.Log("Destroy InventoryCanvas");
            Destroy(gameObject);
        }
        else
        {
            GameManager.manager.SetInventoryCanvas(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool InventoryContains(InventoryObject obj)
    {
        foreach(InventoryObject invObj in GameManager.manager.PlayerInventory)
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
        InvOpenAudio.Play();
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
        GameManager.manager.PlayerInventory.Add(invObject);
        InvOpenAudio.Play();
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        foreach(GameObject panel in Panels)
        {
            panel.GetComponent<InventoryPanel>().ClearPanel();
        }
        for (int i = 0; i < GameManager.manager.PlayerInventory.Count; i++)
        {
            Panels[i].GetComponent<InventoryPanel>().SetInventoryObject(GameManager.manager.PlayerInventory[i]);
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
