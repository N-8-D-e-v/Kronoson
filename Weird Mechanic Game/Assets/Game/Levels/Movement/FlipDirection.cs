using UnityEngine;
using Game.General.Utilities.Transformf;

namespace Game.Levels.Movement
{
    [RequireComponent(typeof(IMovement))]
    public class FlipDirection : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        private IMovement movement;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            movement = GetComponent<IMovement>();
        }

        private void Update()
        {
            transform.Flip(movement.InputAxis);
        }
    }
}