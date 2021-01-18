using UnityEngine;
using Utilities.Transformf;
using Game.Levels.General.Physics_2D.Movement;

namespace Game.Levels.General.Physics_2D.Movement.Visuals
{
    [RequireComponent(typeof(Movement))]
    public class FlipDirection : MonoBehaviour
    {
        //Assignables
        private Movement movement;

        private void Awake() => movement = GetComponent<Movement>();

        private void Update() => transform.Flip(movement.Input_Axis);
    }
}
