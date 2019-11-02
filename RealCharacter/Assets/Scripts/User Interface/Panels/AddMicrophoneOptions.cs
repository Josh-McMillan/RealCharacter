using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMicrophoneOptions : MonoBehaviour
{
    private Dropdown microphoneOptions = null;

    private void OnEnable()
    {
        microphoneOptions = GetComponent<Dropdown>();

        if (microphoneOptions.options.Count > 0)
        {
            microphoneOptions.ClearOptions();
        }

        List<string> micOptions = new List<string>();

        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            micOptions.Add(Microphone.devices[i]);
        }

        microphoneOptions.AddOptions(micOptions);
    }
}
