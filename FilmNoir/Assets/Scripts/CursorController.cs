using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour
{
    private int fingerID = -1;
    public Texture2D cursor, hoverCursor;
    public static CursorController instance;
    Camera cam;

    private void Awake()
    {
    #if !UNITY_EDITOR
            fingerID = 0;
    #endif
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
        cam = Camera.main;
    }

    private void Update()
    {
        // Check if mouse is blocked by UI
        if (EventSystem.current.IsPointerOverGameObject(fingerID))
        {
            Default();
            return;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Interactable" || hit.collider.tag == "Collectible")
            {
                Clickable();

            }
            else
            {
                Default();
            }
        }

    }

    public void Clickable()
    {
        Cursor.SetCursor(hoverCursor, Vector3.zero, CursorMode.ForceSoftware);
    }

    public void Default()
    {
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
    }


}
