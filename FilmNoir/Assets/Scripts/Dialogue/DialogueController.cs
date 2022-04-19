using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public List<Button> DialogueOptions = new List<Button>();
    public Text DialogueText;
    public GameObject panel;

    private void Awake()
    {
        if(GameManager.manager.GetDialogCanvas() != null)
        {
            Destroy(gameObject);
        } 
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDialogue(DialogueNode node)
    {
        Debug.Log("Start setting dialogue");

        panel.SetActive(true);

        PlayerController.canMove = false; //lopettaa pelaajan liikkumisen sen ajaksi kunnes dialogi-ikkuna suljetaan
        

        Debug.Log(node.DialogueText);
        this.DialogueText.text = node.DialogueText;

        foreach (Button button in DialogueOptions)
        {
            button.gameObject.SetActive(false);
        }

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

        panel.SetActive(false);

        PlayerController.canMove = true; //antaa pelaajan taas liikkua dialogiboksin sulkemisen jälkeen

    }
}
