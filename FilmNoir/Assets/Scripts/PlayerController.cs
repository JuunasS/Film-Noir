using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    bool clicked;           // bool jolla seurataan onko painettu interactablea
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // jos hiiren vasemmanpuolinen on painettu, suoritetaan
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // luodaan ray jolla katsotaan mihin kohtaan ruudulla on painettu
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);                            //asetetaan sijainti navmesh agentille ja se liikkuu

                if (hit.collider.CompareTag("Interactable"))
                {
                    clicked = true;
                    Debug.Log("Olet klikannut interactablea, yay! et‰isyys ");

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && clicked)    // t‰ll‰ pidet‰‰n huoli ettei ohi k‰velless‰ voi osua interactableen ja vahingossa saada interaction
        {
            Debug.Log("Olet saapunut interactablen luo!");
        }
        clicked = false;
    }
}
