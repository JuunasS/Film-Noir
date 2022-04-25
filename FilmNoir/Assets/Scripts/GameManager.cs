using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public GameState GameState;

    public NPCInfo[] NPCList = new NPCInfo[20];

    private GameObject DialogCanvas;
    private GameObject InventoryCanvas;

    [SerializeField]
    private InventoryObject HeldObject;

    public GameObject[] interactables;

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

    void Start()
    {
        DialogCanvas = GameObject.Find("DialogueCanvas");
        InventoryCanvas = GameObject.Find("InventoryCanvas");
        CheckInteractables();

        //lis‰t‰‰n NPC:it‰ listalle johon tallennetaan keskusteluiden kulku
        NPCList[0] = new NPCInfo("PawnshopNPC", DialogueMode.FIRST_DIALOGUE);
        NPCList[1] = new NPCInfo("testNPC", DialogueMode.FIRST_DIALOGUE);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryCanvas.GetComponent<InventoryController>().ToggleInventory();
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
        CheckInteractables();
    }

    public void CheckInteractables()
    {
        interactables = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (GameObject obj in interactables)
        {
            Debug.Log("Interactables foreach loop 1");

            if(obj.gameObject.GetComponent<PickableItem>() != null)
            {
                if (InventoryCanvas.GetComponent<InventoryController>().InventoryContains(obj.gameObject.GetComponent<PickableItem>().InventoryObject))
                {
                    Debug.Log("Interactables foreach loop 3");
                    Destroy(obj);
                }
            }
        }
    }

    public void SetDialogue(DialogueNode node)
    {
        DialogCanvas.GetComponent<DialogueController>().SetDialogue(node);
    }


    public void AddItemToInventory(InventoryObject obj)
    {
        InventoryCanvas.GetComponent<InventoryController>().AddItem(obj);
    }

    public void SetDescription(string name, string description, Sprite image)
    {
        InventoryCanvas.GetComponent<InventoryController>().DisplayDescription(name, description, image);
    }

    public void DisableDescriptionPanel()
    {
        InventoryCanvas.GetComponent<InventoryController>().DisableDescription();
    }

    public GameObject GetInventoryCanvas()
    {
        return InventoryCanvas;
    }

    public GameObject GetDialogCanvas()
    {
        return DialogCanvas;
    }

    public void SetHeldObject(InventoryObject invObj)
    {
        this.HeldObject = invObj;
    }

    public InventoryObject GetHeldObject()
    {
        return HeldObject;
    }

    public void SetGameState(GameState newGameState)
    {
        this.GameState = newGameState;
    }
}
