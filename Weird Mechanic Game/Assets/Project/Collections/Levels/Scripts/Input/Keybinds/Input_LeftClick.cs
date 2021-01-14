using UnityEngine;

public class Input_LeftClick : Input_Base
{   
    public bool Clicking
    {
        private set => Clicking = value;

        get
        {
            return Enabled ? Input.GetMouseButton(0) : false;
        }
    }

    public bool Clicked
    {
        private set => Clicked = value;

        get
        {
            return Enabled ? Input.GetMouseButtonDown(0) : false;
        }
    }

    public bool UnClicked
    {
        private set => UnClicked = value;

        get
        {
            return Enabled ? Input.GetMouseButtonUp(0) : false;
        }
    }
}
