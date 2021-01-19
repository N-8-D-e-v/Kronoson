using UnityEngine;
using Game.Levels.Movement;

namespace Game.Inputs.Controls
{
    [RequireComponent(typeof(IMovement), typeof(Jumping))]
    public class ControlsMovement : Controls
    {
        //Assignables
        private IMovement movement;
        private Jumping jumping;

        private void Awake()
        {
            movement = GetComponent<IMovement>();
            jumping = GetComponent<Jumping>();
        }

        protected override void Enabled()
        {
            movement.InputAxis = Input.GetAxisRaw("Horizontal");
            jumping.InputUp = Input.GetAxisRaw("Vertical") > 0;
        }

        protected override void NotEnabled()
        {
            movement.InputAxis = 0f;
            jumping.InputUp = false;
        }
    }
}