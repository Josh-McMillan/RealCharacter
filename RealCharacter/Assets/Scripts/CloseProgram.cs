using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseProgram : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting application");
            Application.Quit();
        }
    }
}
