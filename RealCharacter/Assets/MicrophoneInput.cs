using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : BaseInput
{
    [SerializeField] private MicrophoneStreamer streamer;

    [SerializeField] private float cutoffVolume = 0.0f;

    public override float GetInput()
    {
        float returnVolume = streamer.MaxVolume();

        if (returnVolume > cutoffVolume)
        {
            return streamer.MaxVolume();
        }

        return 0.0f;
    }
}
