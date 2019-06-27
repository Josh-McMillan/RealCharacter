using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseOnBlur : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool mouseHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseHover = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !mouseHover)
        {
            gameObject.SetActive(false);
        }
    }
}
