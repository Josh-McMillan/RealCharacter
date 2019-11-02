using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkInput : BaseInput
{
    public static Action ManualBlink;

    private bool doBlink = false;

    private float currentBlinkTime = 0.0f;

    [SerializeField] private float blinkRate = 0.005f;

    [SerializeField] private KeyCode manualKey;

    private void OnEnable()
    {
        BlinkController.AutoBlink += PerformBlink;
    }

    private void OnDisable()
    {
        BlinkController.AutoBlink -= PerformBlink;
    }

    private void Update()
    {
        if (doBlink)
        {
            currentBlinkTime += blinkRate;

            if (currentBlinkTime > 1.0f)
            {
                doBlink = false;
                currentBlinkTime = 0.0f;
            }
        }
        else if (Input.GetKeyDown(manualKey))
        {
            doBlink = true;
            ManualBlink();
        }
    }

    public override float GetInput()
    {
        return currentBlinkTime;
    }

    private void PerformBlink()
    {
        doBlink = true;
    }
}
