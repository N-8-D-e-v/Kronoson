using UnityEngine;
using Game.General.Utilities.Transformf;

namespace Game.Levels.Movement
{
    [RequireComponent(typeof(SmoothMovement))]
    public class FlipDirection : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        private SmoothMovement movement;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            movement = GetComponent<SmoothMovement>();
        }

        private void Update() => transform.Flip(movement.Input_Axis);
    }
}
