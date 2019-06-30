using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipJump : MonoBehaviour
{
    private RectTransform myTransform = null;

    private Vector2 jumpPoint = Vector2.zero;

    [SerializeField] private Canvas parentCanvas = null;

    private void Start()
    {
        myTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.mousePosition.x > Screen.width - 200)
        {
            myTransform.pivot = new Vector2(1.0f, 1.0f);
        }
        else
        {
            myTransform.pivot = new Vector2(0.0f, 1.0f);
        }

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform, Input.mousePosition,
            parentCanvas.worldCamera, out jumpPoint
        );


        transform.position = parentCanvas.transform.TransformPoint(jumpPoint);
    }
}
