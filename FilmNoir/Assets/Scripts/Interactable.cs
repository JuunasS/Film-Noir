using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false; //pit‰‰ kirjaa onko jonkin kanssa interactattu jo

    /*
    public virtual void Interact()
    {
        // katsotaan miten tehd‰‰n, mutta tutoriaalissa t‰st‰ tehtiin virtuaalifunktio koska t‰m‰n koodin on tarkoitus olla
        // yhteinen kaikille interactable objekteille, joten pit‰isi tehd‰ erikseen skriptit eri objekteille, mutta katsotaan
        Debug.Log("Interacting with " + transform.name);
    }
    */
    void Update()
    {

        if (isFocus && !hasInteracted)  // jos jotain interactablea on painettu ensimm‰ist‰ kertaa/ painamisten v‰liss‰ ollaan liikuttu pois
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("Interacting with " + transform.name);
                hasInteracted = true;
            }
        }

    }

    public void OnFocused(Transform playerTransform)    //interactable tiet‰‰ ett‰ sit‰ on painettu
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

    private void OnDrawGizmosSelected()     // t‰ll‰ piirret‰‰n vaan muokkausta helpottava kuvitus esineen radiuksesta
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
