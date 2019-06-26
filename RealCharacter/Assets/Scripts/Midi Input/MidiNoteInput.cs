using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public enum MidiNotes
{
    C = 0,
    Cs = 1,
    D = 2,
    Ds = 3,
    E = 4,
    F = 5,
    Fs = 6,
    G = 7,
    Gs = 8,
    A = 9,
    As = 10,
    B = 11
}

public enum NoteInputType
{
    Pressed,
    Held,
    Released
}

public class MidiNoteInput : BaseInput
{
    [SerializeField] private MidiChannel midiChannel = MidiChannel.All;

    [SerializeField] private MidiNotes midiNote = MidiNotes.C;

    [SerializeField] private int ocatave = 4;

    [SerializeField] private NoteInputType inputType = NoteInputType.Pressed;

    [SerializeField] private float positiveValue = 1.0f;

    [SerializeField] private float negativeValue = 0.0f;

    public override float GetInput()
    {
        switch (inputType)
        {
            case NoteInputType.Pressed:
                return MidiMaster.GetKeyDown(midiChannel, (int)midiNote + ocatave + 12) ? positiveValue : negativeValue;

            case NoteInputType.Held:
                return MidiMaster.GetKey(midiChannel, (int)midiNote + ocatave + 12);

            case NoteInputType.Released:
                return MidiMaster.GetKeyUp(midiChannel, (int)midiNote + ocatave + 12) ? positiveValue : negativeValue;
        }

        return 0.0f;
    }
}
