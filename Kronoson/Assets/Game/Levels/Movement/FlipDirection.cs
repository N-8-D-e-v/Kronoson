using UnityEngine;
using Game.General.Utilities.Transforms;

namespace Game.Levels.Movement
{
    [RequireComponent(typeof(IMovement))]
    public class FlipDirection : MonoBehaviour, IFlippable
    {
        //Public Fields
        public bool Enabled { set; get; } = true;
        
        //Assignables
        private new Transform transform;
        private IMovement movement;
        
        //Scale
        private float xScale = 1f;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            movement = GetComponent<IMovement>();
            xScale = transform.localScale.x;
        }

        private void Update()
        {
            if (Enabled)
                transform.Flip(movement.InputAxis, xScale);
        }
    }
}