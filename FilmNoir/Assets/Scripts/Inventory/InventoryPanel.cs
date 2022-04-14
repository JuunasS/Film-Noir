using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryObject obj;
    public BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector2(60, 60);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetInventoryObject(InventoryObject obj)
    {
        this.obj = obj;
        this.GetComponentInChildren<Image>().sprite = obj.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Panel entered");
        if(obj)
        {
            GameManager.manager.SetDescription(obj.ItemName, obj.Description, obj.sprite);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Panel exited");
        GameManager.manager.DisableDescriptionPanel();
    }

}
