using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour
{
    public int selectedCamera;

    [SerializeField] private RectTransform frameRect = null;

    [SerializeField] private UIFrame frameUI = null;

    private WebCamDevice[] devices;

    private RawImage picture;

    private AspectRatioFitter arf;

    private WebCamTexture currentCamera;

    private RectTransform myRect;

    private void Start()
    {
        picture = GetComponent<RawImage>();
        arf = GetComponent<AspectRatioFitter>();
        myRect = GetComponent<RectTransform>();

        devices = WebCamTexture.devices;

        PrintCameras();

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

        frameRect.sizeDelta = new Vector2(myRect.rect.width + frameUI.Size, myRect.rect.height + frameUI.Size);
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
