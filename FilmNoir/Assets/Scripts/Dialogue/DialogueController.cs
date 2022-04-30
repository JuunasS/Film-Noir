using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public List<Button> DialogueOptions = new List<Button>();

    public Text SpeakerNameText;
    public Text DialogueText;
    public GameObject panel;
    public static bool isConversationActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("DialogController Start");
        if (GameManager.manager.GetDialogCanvas() != null)
        {
            Debug.Log("Destroy DialogController");
            Destroy(gameObject);
        }
        else
        {
            GameManager.manager.SetDialogCanvas(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDialogue(DialogueNode node)
    {
        Debug.Log("Start setting dialogue");
        isConversationActive = true;    //laitetaan bool joka vahtii onko jokin keskustelu käynnissä trueksi
        panel.SetActive(true);

        PlayerController.canMove = false; //lopettaa pelaajan liikkumisen sen ajaksi kunnes dialogi-ikkuna suljetaan
        
        // Show text
        Debug.Log(node.DialogueText);
        this.DialogueText.text = node.DialogueText;

        // Show name of current speaker
        this.SpeakerNameText.text = node.Speaker.Name;
        node.Speaker.NameColor.a = 1;
        this.SpeakerNameText.color = node.Speaker.NameColor;
        

        // Choice buttons set to false
        foreach (Button button in DialogueOptions)
        {
            button.gameObject.SetActive(false);
        }

        // New buttons activated
        for (int i = 0; i < node.ChoiceDialogs.Count; i++)
        {
            DialogueOptions[i].gameObject.SetActive(true);
            DialogueOptions[i].GetComponentInChildren<Text>().text = node.ChoiceDialogs[i].Text;
            if(node.ChoiceDialogs[i].IsExit)
            {
                DialogueOptions[i].onClick.AddListener(ExitDialogue);
            } 
            else
            {
                DialogueOptions[i].onClick.AddListener(node.ChoiceDialogs[i].SetNextNode);
            }
            
        }
    }

    public void ExitDialogue()
    {

        foreach (Button button in DialogueOptions)
        {
            button.gameObject.SetActive(false);
        }

        isConversationActive = false;
        panel.SetActive(false);

        PlayerController.canMove = true; //antaa pelaajan taas liikkua dialogiboksin sulkemisen jälkeen

    }
}
