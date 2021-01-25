using Game.General.Utilities.Vectors;
using Game.General.Utilities.Mouse;
using UnityEngine;

namespace Game.Inputs.LookAtMouse
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyLookAtMouse : MonoBehaviour, ILookAtMouse
    {
        //Public Fields
        public bool Enabled { get; set; } = false;

        //Assignables
        private Rigidbody2D rb;

        //Offset
        [SerializeField] private float offset = 0f;
        [Range(0.1f, 1f)] [SerializeField] private float smoothing = 1f;

        private void Awake() => rb = GetComponent<Rigidbody2D>();

        private void FixedUpdate()
        {
            if (!Enabled)
                return;
            
            float _angle = rb.position.GetAngleToMouse(MouseF.MAINCAMERA_Z) + offset;
            rb.MoveRotation(_angle);
        }
    }
}