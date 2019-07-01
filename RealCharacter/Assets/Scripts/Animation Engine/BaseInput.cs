using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInput : MonoBehaviour
{
    public virtual float GetInput()
    {
        // throw new NotImplementedException("Input \'" + this.name + "\' is not implemented.");
        return 0.0f;
    }
}
