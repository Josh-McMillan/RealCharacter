using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : BaseInput
{
    public static Action AutoBlink;

    [SerializeField] private float miniumumBlinkTime = 3.0f;

    [SerializeField] private float maximumBlinkTime = 5.0f;

    private float timeLeftToBlink = 4.0f;

    private void OnEnable()
    {
        BlinkInput.ManualBlink += ResetTime;

    }

    private void OnDisable()
    {
        BlinkInput.ManualBlink -= ResetTime;
    }

    private void Update()
    {
        if (timeLeftToBlink > 0.0f)
        {
            timeLeftToBlink -= Time.deltaTime;
        }
        else
        {
            Blink();
        }
    }

    private void Blink()
    {
        if (AutoBlink != null)
        {
            AutoBlink();
        }

        Console.UpdateLog("Blinked!");

        ResetTime();
    }

    private void ResetTime()
    {
        timeLeftToBlink = UnityEngine.Random.Range(miniumumBlinkTime, maximumBlinkTime);
    }
}
