using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class MidiCCInput : BaseInput
{
    [SerializeField] private bool isActive = true;

    [SerializeField, Tooltip("Specifies an input to trigger muting.")] private BaseInput muteTrigger = null;

    [Header("MIDI")]

    [SerializeField] private MidiChannel midiChannel = MidiChannel.All;

    [SerializeField] private int CCValue = 0;

    [SerializeField] private float startingValue = 0.0f;

    [Header("Performance")]

    [SerializeField, Tooltip("MIDI polling speed in milliseconds. The faster you poll (the smaller the value), the more performance may be impacted.")]
    private float pollingSpeed = 12.5f;

    private float inputCache = 0.0f;

    private WaitForSeconds pollingDelay;

    private void OnValidate()
    {
        CCValue = Mathf.Clamp(CCValue, 0, 127);
    }

    private void Start()
    {
        pollingDelay = new WaitForSeconds(pollingSpeed / 1000);
    }

    private void OnEnable()
    {
        StartCoroutine(PollMidiData());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public override float GetInput()
    {
        return inputCache;
    }

    IEnumerator PollMidiData()
    {
        while (isActive)
        {
            if (muteTrigger != null)
            {
                if (muteTrigger.GetInput() > 0.0f)
                {
                    inputCache = startingValue;
                    yield return pollingDelay;
                }
                else
                {
                    inputCache = MidiMaster.GetKnob(midiChannel, CCValue, startingValue);
                    yield return pollingDelay;
                }
            }
            else
            {
                inputCache = MidiMaster.GetKnob(midiChannel, CCValue, startingValue);
                yield return pollingDelay;
            }
        }
    }
}
