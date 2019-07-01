using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;
using System.Runtime.InteropServices;

public class MidiMonitor : MonoBehaviour
{
    [SerializeField] private Text devices = null;

    [SerializeField] private Text history = null;

    private void Update()
    {
        var endpointCount = CountEndpoints();

        var temp = "Detected MIDI devices:";
        for (var i = 0; i < endpointCount; i++)
        {
            var id = GetEndpointIdAtIndex(i);
            var name = GetEndpointName(id);
            temp += "\n" + id.ToString("X8") + ": " + name;
        }

        devices.text = temp;

        temp = "Recent MIDI messages:";
        foreach (var message in MidiDriver.Instance.History)
            temp += "\n" + message.ToString();

        history.text = temp;
    }

    [DllImport("MidiJackPlugin", EntryPoint = "MidiJackCountEndpoints")]
    static extern int CountEndpoints();

    [DllImport("MidiJackPlugin", EntryPoint = "MidiJackGetEndpointIDAtIndex")]
    static extern uint GetEndpointIdAtIndex(int index);

    [DllImport("MidiJackPlugin")]
    static extern System.IntPtr MidiJackGetEndpointName(uint id);

    static string GetEndpointName(uint id)
    {
        return Marshal.PtrToStringAnsi(MidiJackGetEndpointName(id));
    }
}
