using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class AddWebcamOptions : MonoBehaviour
{
    private Dropdown cameraSelection = null;

    private void OnEnable()
    {
        cameraSelection = GetComponent<Dropdown>();

        if (cameraSelection.options.Count > 0)
        {
            cameraSelection.ClearOptions();
        }

        List<string> cameraOptions = new List<string>();

        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            // Debug.Log("Webcam available: " + WebCamTexture.devices[i].name);
            cameraOptions.Add(i + " | " + WebCamTexture.devices[i].name);
        }

        cameraSelection.AddOptions(cameraOptions);
    }
}
