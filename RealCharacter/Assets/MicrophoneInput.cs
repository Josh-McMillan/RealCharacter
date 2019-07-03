using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource)), DisallowMultipleComponent]
public class MicrophoneInput : MonoBehaviour
{
    public int currentMicrophoneIndex = 0;

    [HideInInspector] public string currentMicrophone;

    public AudioSource audioSource;

    private void Start()
    {

        currentMicrophone = Microphone.devices[0];

        LogMicrophoneOptionsToConsole();

        ChangeMicrophone(currentMicrophone);
    }

    private void LogMicrophoneOptionsToConsole()
    {
        Debug.Log("Microphone Options:");

        for (int i = 0; i < Microphone.devices.Length; i++)
        {
            Debug.Log(Microphone.devices[i]);
        }

        Debug.Log("- - - - - ");
    }


    private void OnValidate()
    {
        if (Application.isEditor && Application.isPlaying)
        {
            ChangeMicrophone(Microphone.devices[currentMicrophoneIndex]);
        }
    }

    public void StartMicrophone()
    {
        StopMicrophone();
        currentMicrophone = Microphone.devices[currentMicrophoneIndex];
        UpdateMicrophone();
    }

    public void ChangeMicrophone(string microphoneName)
    {
        StopMicrophone();
        currentMicrophone = microphoneName;
        UpdateMicrophone();
    }

    public void ChangeMicrophone(int microphone = 0)
    {
        StopMicrophone();
        currentMicrophone = Microphone.devices[microphone];
        UpdateMicrophone();
    }

    private void StopMicrophone()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        Microphone.End(currentMicrophone);
    }

    private void UpdateMicrophone()
    {
        audioSource.clip = Microphone.Start(currentMicrophone, true, 10, AudioSettings.outputSampleRate);

        Debug.Log("Microphone " + currentMicrophone + " has activated: " + Microphone.IsRecording(currentMicrophone).ToString());

        if (Microphone.IsRecording(currentMicrophone))
        {
            while (!(Microphone.GetPosition(currentMicrophone) > 0))
            {
                Debug.Log("Waiting for connection to " + currentMicrophone);
            }

            Debug.Log("Recording has started with " + currentMicrophone);
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Microphone " + currentMicrophone + " did not start recording!");
        }
    }
}
