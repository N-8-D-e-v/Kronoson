using UnityEngine;

public class Input_WASD : Input_Base
{
    public Vector2 RawAxisInput
    {
        private set => RawAxisInput = value;

        get
        {
            float _x = Input.GetAxisRaw("Horizontal");
            float _y = Input.GetAxisRaw("Vertical");
            return Enabled ? new Vector2(_x, _y).normalized : Vector2.zero;
        }
    }

    public Vector2 AxisInput
    {
        private set => AxisInput = value;

        get
        {
            float _x = Input.GetAxis("Horizontal");
            float _y = Input.GetAxis("Vertical");
            return Enabled ? new Vector2(_x, _y).normalized : Vector2.zero;
        }
    }
}
