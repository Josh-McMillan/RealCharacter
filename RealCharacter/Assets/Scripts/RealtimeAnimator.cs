using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationType
{
    Translate,
    Rotate,
    Scale
}

public enum Axis
{
    X,
    Y,
    Z
}

public class RealtimeAnimator : MonoBehaviour
{
    public BaseInput inputSource;

    public AnimationType animationType = AnimationType.Translate;

    public Axis axis = Axis.X;

    public AnimationCurve animationControl;

    public bool doSmoothing = false;

    public float smoothSpeed = 0.15f;

    private float inputValue = 0.0f;

    private float driverValue;

    private float smoothingVelocity = 0.0f;

    private Vector3 drivingVector = Vector3.zero;

    private void FixedUpdate()
    {
        inputValue = inputSource.GetInput();

        switch (animationType)
        {
            case AnimationType.Translate:

                drivingVector = SetTranslationalDriverVector();

                transform.localPosition = drivingVector;

                break;

            case AnimationType.Rotate:

                drivingVector = SetRotationalDriverVector();

                transform.localRotation = Quaternion.Euler(drivingVector);
                break;

            case AnimationType.Scale:

                drivingVector = SetScalingDriverVector();

                transform.localScale = drivingVector;
                break;
        }
    }

    private void PerformAnimation()
    {
    }

    private float GetInputIfAvailable()
    {
        if (inputSource != null)
        {
            return inputSource.GetInput();
        }

        Debug.LogWarning("WARNING: " + gameObject.name + "\'s RealtimeAnimator is missing an input source!");
        return 0.0f;
    }

    private float SetDriverValue(bool doRotation)
    {
        if (doSmoothing)
        {
            if (doRotation)
            {
                return Mathf.SmoothDampAngle(driverValue, inputValue, ref smoothingVelocity, smoothSpeed);
            }

            return Mathf.SmoothDamp(driverValue, inputValue, ref smoothingVelocity, smoothSpeed);
        }

        return inputValue;
    }

    private Vector3 SetTranslationalDriverVector()
    {
        driverValue = SetDriverValue(false);

        switch (axis)
        {
            case Axis.X:
                return new Vector3(animationControl.Evaluate(driverValue), transform.position.y, transform.position.z);

            case Axis.Y:
                return new Vector3(transform.position.x, animationControl.Evaluate(driverValue), transform.position.z);

            case Axis.Z:
                return new Vector3(transform.position.x, transform.position.y, animationControl.Evaluate(driverValue));
        }

        Debug.LogWarning("WARNING: " + gameObject.name + "\'s RealtimeAnimator could not set driver vector!");
        return Vector3.zero;
    }

    private Vector3 SetRotationalDriverVector()
    {
        driverValue = SetDriverValue(true);

        switch (axis)
        {
            case Axis.X:
                return new Vector3(animationControl.Evaluate(driverValue), 0.0f, 0.0f);

            case Axis.Y:
                return new Vector3(0.0f, animationControl.Evaluate(driverValue), 0.0f);

            case Axis.Z:
                return new Vector3(0.0f, 0.0f, animationControl.Evaluate(driverValue));
        }

        Debug.LogWarning("WARNING: " + gameObject.name + "\'s RealtimeAnimator could not set driver vector!");
        return Vector3.zero;
    }

    private Vector3 SetScalingDriverVector()
    {
        driverValue = SetDriverValue(false);

        switch (axis)
        {
            case Axis.X:
                return new Vector3(animationControl.Evaluate(driverValue), transform.localScale.y, transform.localScale.z);

            case Axis.Y:
                return new Vector3(transform.localScale.x, animationControl.Evaluate(driverValue), transform.localScale.z);

            case Axis.Z:
                return new Vector3(transform.localScale.x, transform.localScale.y, animationControl.Evaluate(driverValue));
        }

        Debug.LogWarning("WARNING: " + gameObject.name + "\'s RealtimeAnimator could not set driver vector!");
        return Vector3.zero;
    }
}
