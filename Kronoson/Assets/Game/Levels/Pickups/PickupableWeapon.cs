using Game.Inputs.Controls;
using Game.Inputs.LookAtMouse;
using Game.Levels.Player;
using UnityEngine;

namespace Game.Levels.Pickups
{
    [RequireComponent( typeof(ILookAtMouse), typeof(IOnMouseOverlap))]
    [RequireComponent(typeof(ControlsAttack), typeof(Rigidbody2D))]
    [RequireComponent(typeof(IGoToPlayer))]
    public class PickupableWeapon : MonoBehaviour, IPickupable
    {
        //Assignables
        private ILookAtMouse lookAtMouse;
        private IOnMouseOverlap onMouseOverlap;
        private ControlsAttack controlsAttack;
        private Rigidbody2D rb;
        private IGoToPlayer goToPlayer;

        //Picked Up
        [SerializeField] 
        private Vector2 pickedUpOffset = new Vector2(0, 0.1f);
        
        //Physics
        private float gravityScale = 2f;
        private Vector2 centerOfMass = new Vector2();

        private void Awake()
        {
            lookAtMouse = GetComponent<ILookAtMouse>();
            onMouseOverlap = GetComponent<IOnMouseOverlap>();
            controlsAttack = GetComponent<ControlsAttack>();
            rb = GetComponent<Rigidbody2D>();
            gravityScale = rb.gravityScale;
            centerOfMass = rb.centerOfMass;
            goToPlayer = GetComponent<IGoToPlayer>();
        }

        public bool CanPickUp() => onMouseOverlap.IsMouseDownAndOverlapping();

        public void PickUp()
        {
            lookAtMouse.Enabled = true;
            onMouseOverlap.Enabled = false;
            controlsAttack.IsEnabled = true;
            goToPlayer.Enabled = true;
            rb.gravityScale = 0f;
            rb.centerOfMass = Vector2.zero;
        }

        public void Drop()
        {
            lookAtMouse.Enabled = false;
            onMouseOverlap.Enabled = true;
            controlsAttack.IsEnabled = false;
            goToPlayer.Enabled = false;
            rb.gravityScale = gravityScale;
            rb.centerOfMass = centerOfMass;
        }
    }
}