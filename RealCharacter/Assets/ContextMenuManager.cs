using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuManager : MonoBehaviour
{
    private static GameObject contextMenu;

    private void Start()
    {
        contextMenu = GameObject.Find("Context Menu");
    }

    public void ShowContextMenu()
    {
        contextMenu.SetActive(true);
    }
}
