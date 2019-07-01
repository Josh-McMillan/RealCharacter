using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    private Transform cameraTransform = null;
    private Transform parentTransform = null;

    private Vector3 localRotation = Vector3.zero;
    private float cameraDistance = 10.0f;

    public float mouseSensitivity = 4.0f;
    public float scrollSensitivity = 2.0f;
    public float orbitDampening = 10.0f;
    public float scrollDampening = 6.0f;

    public bool CameraDisabled = false;

    private void Start()
    {
        cameraTransform = this.transform;
        parentTransform = this.transform.parent;
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            CameraDisabled = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            CameraDisabled = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (!CameraDisabled)
        {
            if (Input.GetMouseButton(0))
            {
                // Camera Rotations
                if (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f)
                {
                    localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                    localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
                    localRotation.y = Mathf.Clamp(localRotation.y, 0.0f, 90f);
                }
            }

            // Camera Dollying

            if (Input.GetAxis("Mouse ScrollWheel") != 0.0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

                scrollAmount *= (this.cameraDistance * 0.3f);

                this.cameraDistance += scrollAmount * -1.0f;

                this.cameraDistance = Mathf.Clamp(this.cameraDistance, 1.5f, 100.0f);
            }
        }

        // Transforms
        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, localRotation.z);
        this.parentTransform.rotation = Quaternion.Lerp(this.parentTransform.rotation, QT, Time.deltaTime * orbitDampening);

        if (this.cameraTransform.localRotation.z != this.cameraDistance * -1.0f)
        {
            this.cameraTransform.localPosition = new Vector3(this.cameraTransform.localPosition.x, this.cameraTransform.localPosition.y, Mathf.Lerp(this.cameraTransform.localPosition.z, this.cameraDistance * -1.0f, Time.deltaTime * scrollDampening));
        }
    }
}
