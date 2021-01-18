using UnityEngine;
using Game.Levels.Movement;

namespace Game.Inputs.Controls
{
    [RequireComponent(typeof(SmoothMovement), typeof(Jumping))]
    public class Controls_Movement : Controls
    {
        //Assignables
        private SmoothMovement movement;
        private Jumping jumping;

        private void Awake()
        {
            movement = GetComponent<SmoothMovement>();
            jumping = GetComponent<Jumping>();
        }

        protected override void Enabled()
        {
            movement.Input_Axis = Input.GetAxisRaw("Horizontal");
            jumping.Input_Up = Input.GetAxisRaw("Vertical") > 0;
        }

        protected override void NotEnabled()
        {
            movement.Input_Axis = 0f;
            jumping.Input_Up = false;
        }
    }
}
