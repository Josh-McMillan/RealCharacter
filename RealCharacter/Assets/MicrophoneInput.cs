using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : BaseInput
{
    public MicrophoneStreamer streamer;

    public float cutoffVolume = 0.0f;

    private float returnVolume = 0.0f;

    public override float GetInput()
    {
        returnVolume = streamer.MaxVolume();

        if (returnVolume > cutoffVolume)
        {
            return streamer.MaxVolume();
        }

        return 0.0f;
    }
}
