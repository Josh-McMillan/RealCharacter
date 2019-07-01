using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string help = "";

    private GameObject tooltip;

    private Text tooltipText;

    void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltipText = GameObject.Find("TooltipText").GetComponent<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ToolbarTooltips.DoShowTooltips)
        {
            tooltip.SetActive(true);
            tooltipText.text = help;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ToolbarTooltips.DoShowTooltips)
        {
            tooltip.SetActive(false);
        }
    }
}
