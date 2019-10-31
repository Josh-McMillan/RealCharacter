using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage), typeof(AspectRatioFitter))]
public class Webcam : MonoBehaviour
{
    public static WebCamDevice[] devices = null;

    [SerializeField] private WebcamUpdateHandler updateHandler;

    private bool hasInitialized = false;

    private int selectedCamera = 0;

    private RawImage picture = null;

    private AspectRatioFitter arf = null;

    private WebCamTexture currentCamera = null;

    private void Start()
    {
        picture = GetComponent<RawImage>();
        arf = GetComponent<AspectRatioFitter>();
    }

    private void OnEnable()
    {
        if (hasInitialized)
        {
            updateHandler.OnCameraUpdate += SetCamera;
            SetCamera(updateHandler.GetCurrentCamera());
        }
        else
        {
            hasInitialized = true;
        }
    }

    private void OnDisable()
    {
        updateHandler.OnCameraUpdate -= SetCamera;
    }

    private void Update()
    {
        while (currentCamera.width < 100)
        {
            // Debug.Log("Waiting for accurate picture information...");
            return;
        }

        float videoRatio = (float)currentCamera.width / (float)currentCamera.height;
        arf.aspectRatio = videoRatio;
    }

    public void SetCamera(int cameraIndex)
    {
        devices = WebCamTexture.devices;

        Console.UpdateLog("Switching camera to " + devices[cameraIndex].name);

        if (cameraIndex <= devices.Length)
        {
            if (currentCamera != null && currentCamera.isPlaying)
            {
                currentCamera.Stop();
            }

            currentCamera = new WebCamTexture(devices[cameraIndex].name);

            if (picture != null)
            {
                picture.material.mainTexture = currentCamera;

                picture.enabled = false;
                picture.enabled = true;
            }

            currentCamera.Play();
        }
    }
}
