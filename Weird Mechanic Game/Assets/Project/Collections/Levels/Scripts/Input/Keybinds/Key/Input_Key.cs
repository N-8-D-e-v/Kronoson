using UnityEngine;
using System;

public class Input_Key : Input_Base
{
    public bool IsHoldingDown
    {
        private set => IsHoldingDown = value;

        get
        {
            return Enabled ? Input.GetKey(StringToKeyCode()) : false;
        }
    }

    public bool IsDown
    {
        private set => IsDown = value;

        get
        {
            return Enabled ? Input.GetKeyDown(StringToKeyCode()) : false;
        }
    }

    public bool IsUp
    {
        private set => IsUp = value;

        get
        {
            return Enabled ? Input.GetKeyUp(StringToKeyCode()) : false;
        }
    }

    public float Axis
    {
        private set => Axis = value;

        get
        {
            float _axis = Input.GetKey(StringToKeyCode()) ? 1 : 0;
            return Enabled ? _axis : 0f;
        }
    }

    protected virtual string GetKey()
    {
        return "";
        //PUT YOUR DESIRED KEY IN HERE
    }

    KeyCode StringToKeyCode()
    {
        KeyCode _key = (KeyCode) Enum.Parse(typeof(KeyCode), GetKey());
        return _key;
    }
}
