using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam;
    PlayerMotor motor;

    public Interactable focus;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // liikutetaan pelaaja sen luokse mihin klikataan

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                else
                {
                    motor.MoveToPoint(hit.point);
                    RemoveFocus();
                }

            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)       // jos klikataan uutta interactable objektia
        {
            if (focus != null)
                focus.OnDefocused();    // otetaan edellinen interactable pois fokusoinnista

            focus = newFocus;       // asetetaan uusi interactable
            motor.FollowTarget(newFocus);      //ryhdyt‰‰n seuraamaan uutta interactablea
        }
        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }


}
