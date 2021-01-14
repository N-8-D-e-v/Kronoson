using UnityEngine;

public class Input_MousePosition : Input_Base
{
    public Vector2 MousePosition
    {
        private set => MousePosition = value;
        
        get
        {
            return Enabled ? Input.mousePosition : Vector3.zero;
        }
    }

    public Vector2 MouseAxis
    {
        private set => MouseAxis = value;

        get
        {
            float _x = Input.GetAxis("Mouse X");
            float _y = Input.GetAxis("Mouse Y");
            return Enabled ? new Vector2(_x, _y) : Vector2.zero;
        }
    }
}
