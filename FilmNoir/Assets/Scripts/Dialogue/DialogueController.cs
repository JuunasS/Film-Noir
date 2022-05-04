using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public List<Button> DialogueOptions = new List<Button>();

    public Button largeDialogButton;

    public Text SpeakerNameText;
    public Text DialogueText;
    public GameObject panel;
    public static bool isConversationActive = false;

    public DialogueNode currentDialogue;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("DialogController Start");
        if (GameManager.manager.GetDialogCanvas() != null)
        {
            //Debug.Log("Destroy DialogController");
            Destroy(gameObject);
        }
        else
        {
            GameManager.manager.SetDialogCanvas(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetDialogue(DialogueNode node)
    {
        currentDialogue = node;

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
            largeDialogButton.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
        }


        if(node.ChoiceDialogs.Count == 1)
        {
            largeDialogButton.gameObject.SetActive(true);
            largeDialogButton.GetComponentInChildren<Text>().text = node.ChoiceDialogs[0].Text;
            if (node.ChoiceDialogs[0].IsExit)
            {
                largeDialogButton.onClick.AddListener(node.ChoiceDialogs[0].ExitDialogue);
            }
            else
            {
                largeDialogButton.onClick.AddListener(node.ChoiceDialogs[0].SetNextNode);
            }
        }
        else
        {
            // New buttons activated
            for (int i = 0; i < node.ChoiceDialogs.Count; i++)
            {
                DialogueOptions[i].gameObject.SetActive(true);
                DialogueOptions[i].GetComponentInChildren<Text>().text = node.ChoiceDialogs[i].Text;
                if (node.ChoiceDialogs[i].IsExit)
                {
                    DialogueOptions[i].onClick.AddListener(node.ChoiceDialogs[i].ExitDialogue);
                }
                else
                {
                    DialogueOptions[i].onClick.AddListener(node.ChoiceDialogs[i].SetNextNode);
                }
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
