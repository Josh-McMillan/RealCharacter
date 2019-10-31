using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicPanels;

public class ToolbarPanelToggle : MonoBehaviour
{
    [SerializeField] private Image buttonImage = null;

    [SerializeField] private Sprite showPanelSprite = null;

    [SerializeField] private Sprite hidePanelSprite = null;

    [SerializeField] private RectTransform panelContent = null;

    [SerializeField] private DynamicPanelsCanvas canvas = null;

    private Panel myPanel = null;

    private void Start()
    {
        myPanel = PanelUtils.CreatePanelFor(panelContent, canvas);
        buttonImage.sprite = showPanelSprite;

        HidePanel();
    }

    public void OnClick()
    {
        if (myPanel.gameObject.activeInHierarchy)
        {
            HidePanel();
        }
        else
        {
            ShowPanel();
        }
    }

    private void ShowPanel()
    {
        myPanel.gameObject.SetActive(true);
        buttonImage.sprite = hidePanelSprite;
    }

    private void HidePanel()
    {
        myPanel.gameObject.SetActive(false);
        buttonImage.sprite = showPanelSprite;
    }
}
