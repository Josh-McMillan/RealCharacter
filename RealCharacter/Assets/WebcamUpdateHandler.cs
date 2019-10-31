using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WebcamUpdateHandler : MonoBehaviour
{
    private int currentlySelectedCamera = 0;

    public Action<int> OnCameraUpdate;

    public int GetCurrentCamera()
    {
        return currentlySelectedCamera;
    }

    public void UpdateCamera(int camera)
    {
        currentlySelectedCamera = camera;

        if (OnCameraUpdate != null)
        {
            OnCameraUpdate(currentlySelectedCamera);
        }
    }
}
