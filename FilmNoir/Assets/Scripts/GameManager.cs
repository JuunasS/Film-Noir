using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public GameObject DialogCanvas;
    public GameObject InventoryCanvas;

    private void Awake()
    {
        if (manager == null)
        {
            // If manager does not exist don't destroy this
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            // If manager already exists in scene destroy this
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Used for adding checking items in scene
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (GameObject obj in interactables)
        {
            Debug.Log("Interactables foreaach loop");
            if (obj.GetComponent<InventoryObject>() != null)
            {
                if (PlayerPrefs.GetString(obj.gameObject.GetComponent<InventoryObject>().ItemName) != null)
                {
                    Destroy(obj);
                }
            }
        }
    }

    void Start()
    {
        DialogCanvas = GameObject.Find("DialogueCanvas");
        InventoryCanvas = GameObject.Find("InventoryCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryCanvas.GetComponent<InventoryController>().ToggleInventory();
        }
    }

    public void SetDialogue(DialogueNode node)
    {
        DialogCanvas.GetComponent<DialogueController>().SetDialogue(node);
    }


    public void AddItemToInventory(InventoryObject obj)
    {
        InventoryCanvas.GetComponent<InventoryController>().AddItem(obj);

        // Siirrä?
        PlayerPrefs.SetString(obj.ItemName, "Collected");
    }

    public void SetDescription(string name, string description, Sprite image)
    {
        InventoryCanvas.GetComponent<InventoryController>().DisplayDescription(name, description, image);
    }

    public void DisableDescriptionPanel()
    {
        InventoryCanvas.GetComponent<InventoryController>().DisableDescription();
    }

}
