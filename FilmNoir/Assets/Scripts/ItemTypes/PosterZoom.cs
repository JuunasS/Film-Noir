using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterZoom : Interactable
{
    public GameObject imagePanel;

    public override void Interact()
    {
        base.Interact();
        imagePanel.SetActive(true);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
