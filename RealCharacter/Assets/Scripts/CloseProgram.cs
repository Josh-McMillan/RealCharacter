using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseProgram : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("Quitting application");
        Application.Quit();
    }
}
