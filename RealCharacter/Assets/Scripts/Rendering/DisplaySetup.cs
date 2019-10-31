using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySetup : MonoBehaviour
{
    private void Start()
    {
        Console.UpdateLog("Connected Displays: " + Display.displays.Length);

        // Display.displays[0] is primary, always on!
        // Check and activate for render output:

        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }
    }
}
