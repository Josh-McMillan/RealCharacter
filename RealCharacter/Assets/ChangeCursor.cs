using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Texture2D alteredCursor = null;

    [SerializeField] private Texture2D normalCursor = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Input.GetMouseButton(0))
        {
            if (alteredCursor != null)
            {
                Cursor.SetCursor(alteredCursor, new Vector2(72, 43), CursorMode.Auto);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Input.GetMouseButton(0))
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
