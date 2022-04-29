using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public SimpleDialogue simpleDialogue;
    [HideInInspector] public DialogueNeedsItem dialogWithItem;
    [HideInInspector] public DialogGetItem dialogGetItem;

    private NPCMotor motor;

    public DialogueNode startDialogue;
    public Transform waypoint;

    public DialogueStyle styleOfDialogue;

    private void Awake()
    {
        if (waypoint != null)
        {
            Debug.Log("Started moving");
            gameObject.GetComponent<NavMeshObstacle>().enabled = false;
            motor = GetComponent<NPCMotor>();
        }
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if(waypoint != null && startDialogue != null)
        {
            animator.SetBool("isWalking", true);
            motor.MoveToPointDialogue(waypoint.position);
        }
        else
        {
            motor.MoveToPoint(waypoint.position);
        }
        //inventory = FindObjectOfType<InventoryController>();
    }

    private void Update()
    {
        if (!DialogueController.isConversationActive && animator.GetBool("isTalking") == true)
        {
            animator.SetBool("isTalking", false);
        }
    }

    public void StartDialogue()
    {
        animator.SetBool("isWalking", false);
        GameManager.manager.SetDialogue(startDialogue);
    }

    public void ChooseDialogue()
    {
        if(styleOfDialogue == DialogueStyle.SIMPLE_DIALOGUE)
        {
            simpleDialogue = gameObject.GetComponent<SimpleDialogue>();
            simpleDialogue.DisplayDialogue();
        }
        else if (styleOfDialogue == DialogueStyle.NEEDS_ITEM)
        {
            dialogWithItem = gameObject.GetComponent<DialogueNeedsItem>();
            dialogWithItem.DisplayDialogue();
        }
        else if (styleOfDialogue == DialogueStyle.GET_ITEM)
        {
            dialogGetItem = gameObject.GetComponent<DialogGetItem>();
            dialogGetItem.DisplayDialogue();
        }
        else if (styleOfDialogue == DialogueStyle.DEFAULT)
        {
            Debug.Log("Et ole laittanut dialogityyppi� t�lle NPC:lle");
        }
    }

}

// toimii helpottamaan dialogien sis�ll�n muistamista
public enum DialogueMode
{
    FIRST_DIALOGUE,
    SECOND_DIALOGUE,
    THIRD_DIALOGUE
}

public enum DialogueStyle
{
    DEFAULT,
    SIMPLE_DIALOGUE,
    NEEDS_ITEM,
    GET_ITEM
}


//Toimii indeksin� kun hy�dynnet��n game managerissa olevaa listaa t�ynn� NPC:iden dialogin kulkua
public enum NPCName // t�nne merkitt�v� eri NPC:iden nimet, ja sitten pidett�v� ne gameManagerissa samassa j�rjestyksess�
{
    PAWNSHOPNPC = 0,
    BARBARA,
    SINGER,
    GANGSTER,
    HAIRDRESSER,
    ANTAGONIST,
    BARTENDER,
    MISTRESS,
    NINA,
    CHEATER,
    CLIENT_JUDY
}

// luokka josta tehd��n olioita joita tallennetaan game managerissa olevaan listaan
public class NPCInfo
{
    public string name;
    public DialogueMode dialogueProgress;

    public NPCInfo(string newName, DialogueMode newDialogueProgress)
    {
        name = newName;
        dialogueProgress = newDialogueProgress;
    }
}