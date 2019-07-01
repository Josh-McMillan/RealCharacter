using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolbarTooltips : MonoBehaviour
{
    public static bool DoShowTooltips = false;

    public static float hoverTime = 1.0f;

    [SerializeField] private Sprite showTooltips = null;

    [SerializeField] private Sprite hideTooltips = null;

    private Image button = null;

    private GameObject tooltipBox = null;

    private void Start()
    {
        button = GetComponent<Image>();
        tooltipBox = GameObject.Find("Tooltip");

        HideTooltips();
    }

    public void OnClick()
    {
        if (DoShowTooltips)
        {
            HideTooltips();
        }
        else
        {
            ShowToolTips();
        }
    }

    private void ShowToolTips()
    {
        DoShowTooltips = true;
        button.sprite = hideTooltips;
    }

    private void HideTooltips()
    {
        DoShowTooltips = false;
        button.sprite = showTooltips;
        tooltipBox.SetActive(false);
    }
}
