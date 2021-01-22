using Game.Inputs.Controls;
using Game.Inputs.LookAtMouse;
using UnityEngine;

namespace Game.Levels.Pickups
{
    [RequireComponent(typeof(HingeJoint2D), typeof(ILookAtMouse))]
    [RequireComponent(typeof(Rigidbody2D), typeof(IOnMouseOverlap))]
    [RequireComponent(typeof(ControlsAttack))]
    public class PickupableWeapon : MonoBehaviour, IPickupable
    {
        //Assignables
        private HingeJoint2D joint;
        private ILookAtMouse lookAtMouse;
        private Rigidbody2D rb;
        private IOnMouseOverlap onMouseOverlap;
        private ControlsAttack controlsAttack;

        //Picked Up
        [Header("Picked Up")]
        [SerializeField] private Vector2 pickedUpOffset = new Vector2(0, 0.1f);
        
        //Layers
        [Header("Layers")]
        [SerializeField] private int pickedUpLayer = 0;
        [SerializeField] private int droppedLayer = 0;
        
        //Physics
        private float gravityScale = 2f;
        private float drag = 15f;

        private void Awake()
        {
            joint = GetComponent<HingeJoint2D>();
            lookAtMouse = GetComponent<ILookAtMouse>();
            rb = GetComponent<Rigidbody2D>();
            gravityScale = rb.gravityScale;
            drag = rb.drag;
            rb.drag = 0f;
            onMouseOverlap = GetComponent<IOnMouseOverlap>();
            controlsAttack = GetComponent<ControlsAttack>();
        }

        public bool CanPickUp() => onMouseOverlap.IsMouseDownAndOverlapping();

        public void PickUp(Rigidbody2D _pickUp)
        {
            AttatchToPickUp(_pickUp);
            EnableControls();
            DisablePhysics();
            UpdateLayer(pickedUpLayer);
        }

        public void Drop()
        {
            DetatchFromPickUp();
            DisableControls();
            EnablePhysics();
            UpdateLayer(droppedLayer);
        }

        private void AttatchToPickUp(Rigidbody2D _pickUp)
        {
            rb.position = _pickUp.position + pickedUpOffset;
            joint.enabled = true;
            joint.connectedBody = _pickUp;
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

        private void UpdateLayer(int _layer) => gameObject.layer = _layer;
    }
}