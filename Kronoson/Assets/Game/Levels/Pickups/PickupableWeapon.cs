using Game.Inputs.Controls;
using Game.Inputs.LookAtMouse;
using UnityEngine;

namespace Game.Levels.Pickups
{
    [RequireComponent(typeof(RelativeJoint2D), typeof(ILookAtMouse))]
    [RequireComponent(typeof(Rigidbody2D), typeof(IOnMouseOverlap))]
    [RequireComponent(typeof(ControlsAttack))]
    public class PickupableWeapon : MonoBehaviour, IPickupable
    {
        //Assignables
        private RelativeJoint2D joint;
        private ILookAtMouse lookAtMouse;
        private Rigidbody2D rb;
        private IOnMouseOverlap onMouseOverlap;
        private ControlsAttack controlsAttack;

        //Picked Up
        [Header("Picked Up")]
        [SerializeField] private Vector2 pickedUpOffset = new Vector2(0, 0.1f);

        //Physics
        private float gravityScale = 2f;
        private float drag = 15f;

        private void Awake()
        {
            joint = GetComponent<RelativeJoint2D>();
            lookAtMouse = GetComponent<ILookAtMouse>();
            rb = GetComponent<Rigidbody2D>();
            gravityScale = rb.gravityScale;
            drag = rb.drag;
            rb.drag = 0f;
            onMouseOverlap = GetComponent<IOnMouseOverlap>();
            controlsAttack = GetComponent<ControlsAttack>();
        }

        public bool CanPickUp() => onMouseOverlap.IsMouseDownAndOverlapping();

        public void PickUp(Rigidbody2D _attachedRigidbody)
        {
            AttatchToPickUp(_attachedRigidbody);
            EnableControls();
            DisablePhysics();
        }

        public void Drop()
        {
            DetatchFromPickUp();
            DisableControls();
            EnablePhysics();
        }

        private void AttatchToPickUp(Rigidbody2D _attachedRigidbody)
        {
            rb.position = _attachedRigidbody.position + pickedUpOffset;
            joint.enabled = true;
            joint.connectedBody = _attachedRigidbody;
        }

        private void DetatchFromPickUp()
        {
            joint.connectedBody = null;
            joint.enabled = false;
        }

        private void EnableControls()
        {
            lookAtMouse.Enabled = true;
            onMouseOverlap.Enabled = false;
            controlsAttack.IsEnabled = true;
        }

        private void DisableControls()
        {
            lookAtMouse.Enabled = false;
            onMouseOverlap.Enabled = true;
            controlsAttack.IsEnabled = false;
        }

        private void DisablePhysics()
        {
            rb.gravityScale = 0f;
            rb.drag = drag;
        }

        private void EnablePhysics()
        {
            rb.gravityScale = gravityScale;
            rb.drag = 0f;
        }
    }
}