using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour
{
    public int selectedCamera;

    private WebCamDevice[] devices;

    private RawImage picture;

    private AspectRatioFitter arf;

    private WebCamTexture currentCamera;

    private void Start()
    {
        picture = GetComponent<RawImage>();
        arf = GetComponent<AspectRatioFitter>();

        devices = WebCamTexture.devices;

        PrintCameras();

        SetCamera(selectedCamera);
    }

    private void Update()
    {
        if (currentCamera.width < 100)
        {
            Debug.Log("Waiting for accurate picture information...");
            return;
        }

        float videoRatio = (float)currentCamera.width / (float)currentCamera.height;
        arf.aspectRatio = videoRatio;
    }

    private void PrintCameras()
    {
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("Webcam available: " + devices[i].name);
        }
    }

    private void SetCamera(int cameraIndex)
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
