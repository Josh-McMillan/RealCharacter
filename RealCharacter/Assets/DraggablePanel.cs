using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggablePanel : MonoBehaviour
{
    private float offsetX = 0.0f;
    private float offsetY = 0.0f;

    public void BeginDrag()
    {
        offsetX = transform.position.x - Input.mousePosition.x;
        offsetY = transform.position.y - Input.mousePosition.y;
    }

    public void OnDrag()
    {
        transform.position = new Vector3(offsetX + Input.mousePosition.x,
                                         offsetY + Input.mousePosition.y, 0.0f);
    }
}
