using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    public RectTransform myRect = null;

    public float rotationSpeed = 3.0f;

    private bool doRotate = false;

    private float currentRotation = 359f;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (doRotate)
        {
            currentRotation -= rotationSpeed;

            if (currentRotation < 0.0f)
            {
                currentRotation += 360f;
            }

            myRect.rotation = Quaternion.Euler(0.0f, 0.0f, currentRotation);
        }
    }

    private void OnEnable()
    {
        doRotate = true;
    }

    private void OnDisable()
    {
        doRotate = false;
    }
}
