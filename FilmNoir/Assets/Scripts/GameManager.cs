using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string GAMESAVEKEY = "GAMESAVEPREF";
    GameSave GameSave;

    public static GameManager manager;

    public GameState GameState;
    public string currentSceneName;
    public AudioSource GameMusic;

    private GameObject DialogCanvas;
    private GameObject InventoryCanvas;
    private GameObject MenuCanvas;

    public List<InventoryObject> PlayerInventory = new List<InventoryObject>();
    public NPCInfo[] NPCList = new NPCInfo[20];

    [SerializeField]
    private InventoryObject HeldObject;

    public GameObject[] collectables;

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
        currentSceneName = SceneManager.GetActiveScene().name;
        CheckInteractables();

        //lis‰t‰‰n NPC:it‰ listalle johon tallennetaan keskusteluiden kulku
        NPCList[0] = new NPCInfo("PawnshopNPC", DialogueMode.FIRST_DIALOGUE);
        NPCList[1] = new NPCInfo("Barbara", DialogueMode.FIRST_DIALOGUE);
        NPCList[2] = new NPCInfo("Singer", DialogueMode.FIRST_DIALOGUE);
        NPCList[3] = new NPCInfo("Gangster", DialogueMode.FIRST_DIALOGUE);
        NPCList[4] = new NPCInfo("Hairdresser", DialogueMode.FIRST_DIALOGUE);
        NPCList[5] = new NPCInfo("Antagonist", DialogueMode.FIRST_DIALOGUE);
        NPCList[6] = new NPCInfo("Bartender", DialogueMode.FIRST_DIALOGUE);
        NPCList[7] = new NPCInfo("Mistress", DialogueMode.FIRST_DIALOGUE);
        NPCList[8] = new NPCInfo("Nina", DialogueMode.FIRST_DIALOGUE);
        NPCList[9] = new NPCInfo("Cheater", DialogueMode.FIRST_DIALOGUE);
        NPCList[10] = new NPCInfo("Client(Judy)", DialogueMode.FIRST_DIALOGUE);
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

    // Used for checking items in scene
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckInteractables();
        currentSceneName = SceneManager.GetActiveScene().name;
        InventoryCanvas.GetComponent<InventoryController>().UpdateInventory();
        PlayerController.canMove = true;
    }

    public void CheckInteractables()
    {
        collectables = GameObject.FindGameObjectsWithTag("Collectible");

        foreach (GameObject obj in collectables)
        {
            Debug.Log("Interactables foreach loop 1");

            if(obj.gameObject.GetComponent<PickableItem>() != null)
            {
                if(InventoryCanvas != null)
                {
                    if (InventoryCanvas.GetComponent<InventoryController>().InventoryContains(obj.gameObject.GetComponent<PickableItem>().InventoryObject))
                    {
                        Debug.Log("Interactables foreach loop 3");
                        Destroy(obj);
                    }
                }
            }
        }
    }

    public void ToggleMusic()
    {
        GameMusic.mute = !GameMusic.mute;
    }

    public void NpcJoinConversation(string npcName, DialogueNode nextNode)
    {
        GameObject.Find(npcName).GetComponent<NPCcontroller>().JoinConversation(nextNode);
    }
    public void NpcExitConversation(string npcName, DialogueNode nextNode)
    {
        GameObject.Find(npcName).GetComponent<NPCcontroller>().ExitConversation(nextNode);
    }
    public void SetDialogue(DialogueNode node)
    {
        if(DialogCanvas.GetComponent<DialogueController>().currentDialogue != node)
        {
            Debug.Log("Gamemanager setting dialogue");
            DialogCanvas.GetComponent<DialogueController>().SetDialogue(node);
        }
    }

    public void ExitDialogue()
    {
        PlayerController.canMove = true;
        Debug.Log("Gamemanager exit dialogue");
        DialogCanvas.GetComponent<DialogueController>().ExitDialogue();
    }



    public void AddItemToInventory(InventoryObject obj)
    {
        if (!InventoryCanvas.GetComponent<InventoryController>().InventoryContains(obj))
        {
            InventoryCanvas.GetComponent<InventoryController>().AddItem(obj);
        }
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

    public GameObject GetMenuCanvas()
    {
        return MenuCanvas;
    }

    public void SetInventoryCanvas(GameObject invCanvas)
    {
        this.InventoryCanvas = invCanvas;
    }

    public void SetDialogCanvas(GameObject dialogCanvas)
    {
        this.DialogCanvas = dialogCanvas;
    }

    public void SetMenuCanvas(GameObject menuCanvas)
    {
        this.MenuCanvas = menuCanvas;
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

    public void SetMusic(AudioClip newMusic)
    {
        GameMusic.clip = newMusic;
        GameMusic.Play();
    }

    // Saves gamestate and player inventory to playerprefs in JSON format
    public void SavePrefs()
    {
        this.GameSave = new GameSave();
        Debug.Log("Saving playerprefs...");
        this.GameSave.NewData();
        string GameSaveJson = JsonUtility.ToJson(this.GameSave);
        PlayerPrefs.SetString(GAMESAVEKEY, GameSaveJson);
        PlayerPrefs.Save();
    }

    // Loads gamestate and player inventory from playerprefs and converts them beck from JSON format
    public void LoadPrefs()
    {
        PlayerInventory.Clear();
        Debug.Log("Loading playerprefs...");
        string GameSaveJson = PlayerPrefs.GetString(GAMESAVEKEY);

        GameSave LoadGameSave = JsonUtility.FromJson<GameSave>(GameSaveJson);

        if(LoadGameSave != null)
        {
            if(LoadGameSave.GameState != null)
            {
                this.GameState = LoadGameSave.GameState;
                Debug.Log("Found gamestate");
            }
            if(LoadGameSave.InventoryObjects.Count != 0)
            {
                foreach(InventoryObject inventoryObject in LoadGameSave.InventoryObjects)
                {
                    this.PlayerInventory.Add(inventoryObject);
                }
                Debug.Log("Found inventory objects");
            }
            if(LoadGameSave.SceneName != "")
            {
                this.currentSceneName = LoadGameSave.SceneName;
                Debug.Log("Found current scene");
            }
        }
        else
        {
            Debug.Log("No save found");
        }
    }
}


[System.Serializable]
public class GameSave
{
    public GameState GameState;
    public string SceneName;
    public List<InventoryObject> InventoryObjects = new List<InventoryObject>();

    public void NewData()
    {
        Debug.Log("Saving new save data");
        GameState = GameManager.manager.GameState;
        SceneName = GameManager.manager.currentSceneName;
        InventoryObjects.Clear();
        foreach(InventoryObject inventoryObject in GameManager.manager.PlayerInventory)
        {
            InventoryObjects.Add(inventoryObject);
        }
    }

}
