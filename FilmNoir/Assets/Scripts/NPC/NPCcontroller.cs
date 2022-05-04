using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCcontroller : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public SimpleDialogue simpleDialogue;
    [HideInInspector] public DialogueNeedsItem dialogWithItem;
    [HideInInspector] public EndSceneDialogue endScene;

    private NPCMotor motor;

    public DialogueNode startDialogue;
    public Transform waypoint;
    public bool joinsLater;

    public GameObject NPCBody; // when NPC join conversation late
    //and arrives at the scene, this is turned on so they show up in scene

    public DialogueStyle styleOfDialogue;

    public bool isItTheEndScene = false;

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
        if (joinsLater != true)
        {
            if (waypoint != null && startDialogue != null)
            {
                animator.SetBool("isWalking", true);
                motor.MoveToPointDialogue(waypoint.position);
            }
            else if (waypoint != null)
            {
                motor.MoveToPoint(waypoint.position);
            }
        }

        if (joinsLater)
        {
            NPCBody.SetActive(false);
        }
    }

    public void JoinConversation(DialogueNode nextNode)
    {
        NPCBody.SetActive(true);
        animator.SetBool("isWalking", true);
        startDialogue = nextNode;
        motor.reachedDestination = false;
        motor.MoveToPointDialogue(waypoint.position);
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
        animator.SetBool("isTalking", true);

        if (isItTheEndScene)
        {
            endScene = gameObject.GetComponent<EndSceneDialogue>();
            endScene.DisplayDialogue();
        }
        else
        {
            GameManager.manager.SetDialogue(startDialogue);
        }
    }

    public void ChooseDialogue()
    {
        if (styleOfDialogue == DialogueStyle.SIMPLE_DIALOGUE)
        {
            simpleDialogue = gameObject.GetComponent<SimpleDialogue>();
            simpleDialogue.DisplayDialogue();
        }
        else if (styleOfDialogue == DialogueStyle.NEEDS_ITEM)
        {
            dialogWithItem = gameObject.GetComponent<DialogueNeedsItem>();
            dialogWithItem.DisplayDialogue();
        }
        else if (styleOfDialogue == DialogueStyle.DEFAULT)
        {
            Debug.Log("Et ole laittanut dialogityyppiä tälle NPC:lle");
        }
    }

}

// toimii helpottamaan dialogien sisällön muistamista
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
    NEEDS_ITEM
}


//Toimii indeksinä kun hyödynnetään game managerissa olevaa listaa täynnä NPC:iden dialogin kulkua
public enum NPCName // tänne merkittävä eri NPC:iden nimet, ja sitten pidettävä ne gameManagerissa samassa järjestyksessä
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

// luokka josta tehdään olioita joita tallennetaan game managerissa olevaan listaan
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
