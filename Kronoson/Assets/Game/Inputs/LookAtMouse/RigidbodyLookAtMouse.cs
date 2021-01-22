using Game.General.Utilities.Vector3f;
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
        [Range(0.1f, 1f)] [SerializeField] private float smoothing = 10f;

        private void Awake() => rb = GetComponent<Rigidbody2D>();

        private void FixedUpdate()
        {
            if (!Enabled)
                return;
            
            float _angle = ((Vector3) rb.position).GetAngleToMouse(-10) + offset;
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, _angle, smoothing));
        }
    }
}