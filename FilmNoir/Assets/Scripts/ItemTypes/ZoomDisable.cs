using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomDisable : MonoBehaviour, IPointerDownHandler
{
    public GameObject panel;
    public GameObject poster;
    public void OnPointerDown(PointerEventData eventData)
    {
        panel.SetActive(false);
        StartCoroutine("WaitToEnable");

    }

    private IEnumerator WaitToEnable()
    {
        Debug.Log("Wait started");
        yield return new WaitForSeconds(0.2f);
        poster.GetComponent<BoxCollider>().enabled = true;
    }
}
