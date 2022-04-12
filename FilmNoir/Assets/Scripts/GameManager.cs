using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public GameObject DialogCanvas;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        DialogCanvas = GameObject.Find("DialogueCanvas");   //en tied‰ onko paras vaihtoehto, mutta ilman t‰t‰ dialogiboksi ei toimi kun se j‰‰ edelliseen
    }

    public void SetDialogue(DialogueNode node)
    {
        DialogCanvas.GetComponent<DialogueController>().SetDialogue(node);
        /*
        foreach(string text in texts)
        {
            StartCoroutine(AddText(text));
        }
        */
    }

    /*
    IEnumerator AddText(string text)
    {
        dialogueBox.text += text;
        yield return new WaitForSeconds(0.5f);
    }
    */

    // Start is called before the first frame update
   
}
