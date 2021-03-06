using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false; //pit?? kirjaa onko jonkin kanssa interactattu jo

    public Transform interactionTransform; //silt? varalta ett? haluaa muuttaa kohtaa josta interaction tapahtuu

    
    public virtual void Interact()
    {
       
        Debug.Log("Interacting with " + transform.name);
        hasInteracted = true;
    }

    void Update()
    {

        if (isFocus && !hasInteracted)  // jos jotain interactablea on painettu ensimm?ist? kertaa/ painamisten v?liss? ollaan liikuttu pois
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                //Debug.Log("Interacting with " + transform.name);
                hasInteracted = true;
            }
        }

    }

    public void OnFocused(Transform playerTransform)    //interactable tiet?? ett? sit? on painettu
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()     // t?ll? piirret??n vaan muokkausta helpottava kuvitus esineen radiuksesta
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    public Transform GetLocation()
    {
        return interactionTransform;
    }
}
