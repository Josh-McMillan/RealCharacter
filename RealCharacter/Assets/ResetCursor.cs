using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCursor : MonoBehaviour
{
    [SerializeField] private Texture2D normalCursor = null;

    private void Start()
    {
        if (normalCursor != null)
        {
            Cursor.SetCursor(normalCursor, new Vector2(72, 43), CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (normalCursor != null)
            {
                Cursor.SetCursor(normalCursor, new Vector2(72, 43), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
    }
}
