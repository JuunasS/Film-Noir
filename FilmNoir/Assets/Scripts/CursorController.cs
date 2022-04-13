using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursor, hoverCursor;
    public static CursorController instance;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, Vector3.zero, CursorMode.ForceSoftware);
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Interactable")
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
