using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public List<Button> DialogueOptions = new List<Button>();
    public Text DialogueText;
    public GameObject panel;


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
            DialogueOptions[i].onClick.AddListener(node.ChoiceDialogs[i].SetNextNode);
        }
    }
}
