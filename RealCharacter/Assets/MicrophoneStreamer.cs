using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource)), DisallowMultipleComponent]
public class MicrophoneStreamer : MonoBehaviour
{
    public int currentMicrophoneIndex = 0;

    [HideInInspector] public string currentMicrophone;

    public AudioSource audioSource;

    private void Start()
    {
        currentMicrophone = Microphone.devices[0];

        ChangeMicrophone(currentMicrophone);
    }

    private void OnValidate()
    {
        if (Application.isEditor && Application.isPlaying)
        {
            ChangeMicrophone(Microphone.devices[currentMicrophoneIndex]);
        }
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

    public float MaxVolume()
    {
        float levelMax = 0.0f;
        float[] spectrum = new float[512];

        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);

        for (int i = 0; i < spectrum.Length; i++)
        {
            if (levelMax < spectrum[i])
            {
                levelMax = spectrum[i];
            }
        }

        return levelMax;
    }
}
