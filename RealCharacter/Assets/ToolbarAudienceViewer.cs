using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DynamicPanels;

public class ToolbarAudienceViewer : MonoBehaviour
{
    [SerializeField] private Image button = null;

    [SerializeField] private Sprite showViewer = null;

    [SerializeField] private Sprite hideViewer = null;

    [SerializeField] private RectTransform viewerContent = null;

    [SerializeField] private DynamicPanelsCanvas canvas = null;

    private Panel myPanel = null;

    private void Start()
    {
        myPanel = PanelUtils.CreatePanelFor(viewerContent, canvas);

        HideAudienceViewer();
    }

    public void OnClick()
    {
        if (myPanel.gameObject.activeInHierarchy)
        {
            HideAudienceViewer();
        }
        else
        {
            ShowAudienceViewer();
        }
    }

    private void ShowAudienceViewer()
    {
        myPanel.gameObject.SetActive(true);
        button.sprite = hideViewer;
    }

    private void HideAudienceViewer()
    {
        myPanel.gameObject.SetActive(false);
        button.sprite = showViewer;
    }
}
