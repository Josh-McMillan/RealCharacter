using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResizableHeightPanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform cameraViewport;

    private RectTransform frameTransform;

    public UIFrame frame;

    private Vector2 currentPointerPosition;
    private Vector2 previousPointerPosition;

    private bool mouseUp = false;

    private void Start()
    {
        frameTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        cameraViewport.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(frameTransform, data.position, data.pressEventCamera, out previousPointerPosition);

        if (Input.mousePosition.y > transform.position.y)
        {
            mouseUp = true;
        }
        else
        {
            mouseUp = false;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (cameraViewport == null)
        {
            return;
        }

        Vector2 sizeDelta = cameraViewport.sizeDelta;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(frameTransform, data.position, data.pressEventCamera, out currentPointerPosition);
        Vector2 resizeValue = currentPointerPosition - previousPointerPosition;

        if (mouseUp)
        {
            sizeDelta += new Vector2(cameraViewport.sizeDelta.x, resizeValue.y);
        }
        else
        {
            sizeDelta += new Vector2(cameraViewport.sizeDelta.x, -resizeValue.y);
        }

        cameraViewport.sizeDelta = sizeDelta;

        previousPointerPosition = currentPointerPosition;
    }
}
