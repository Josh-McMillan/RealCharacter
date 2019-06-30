using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour
{
    private int selectedCamera = 0;

    private WebCamDevice[] devices = null;

    private RawImage picture = null;

    private AspectRatioFitter arf = null;

    private WebCamTexture currentCamera = null;

    [SerializeField] private Dropdown cameraSelection = null;

    private void Start()
    {
        picture = GetComponent<RawImage>();
        arf = GetComponent<AspectRatioFitter>();

        devices = WebCamTexture.devices;

        LoadCameras();

        SetCamera(selectedCamera);
    }

    private void Update()
    {
        while (currentCamera.width < 100)
        {
            Debug.Log("Waiting for accurate picture information...");
            return;
        }

        float videoRatio = (float)currentCamera.width / (float)currentCamera.height;
        arf.aspectRatio = videoRatio;
    }

    private void LoadCameras()
    {
        List<string> cameraOptions = new List<string>();

        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("Webcam available: " + devices[i].name);
            cameraOptions.Add(i + " | " + devices[i].name);
        }

        cameraSelection.AddOptions(cameraOptions);
    }

    public void SetCamera(int cameraIndex)
    {
        if (cameraIndex <= devices.Length)
        {
            if (currentCamera != null && currentCamera.isPlaying)
            {
                currentCamera.Stop();
            }

            currentCamera = new WebCamTexture(devices[cameraIndex].name);
            picture.material.mainTexture = currentCamera;

            currentCamera.Play();
        }
    }
}
