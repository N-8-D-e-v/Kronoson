using UnityEngine;

namespace Game.Levels.Pickups
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PickUp : MonoBehaviour
    {
        //Assignables
        private Rigidbody2D rb;
        private new Transform transform;
        
        //Picking Up
        [Header("Picking Up")]
        [SerializeField] private float pickUpRadius = 1f;
        [SerializeField] private LayerMask pickupableLayers;
        private Collider2D[] pickupables = new Collider2D[10];

        //Holding
        private IPickupable holding;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            transform = GetComponent<Transform>();
        }

        private void Update()
        {
            int _size = Physics2D.OverlapCircleNonAlloc
                (transform.position, pickUpRadius, pickupables, pickupableLayers);

            CheckDrop();
            if (_size == 0)
                return;

            for (int _i = 0; _i < _size; _i++)
            {
                IPickupable _pickupable = IsPickUp(pickupables[_i]);
                if (_pickupable == null) 
                    continue;

                if (holding != null)
                {
                    holding.Drop();
                    holding = null;
                }
                _pickupable.PickUp(rb);
                holding = _pickupable;
                return;
            }
        }

        private void CheckDrop()
        {
            if (holding == null || !Input.GetMouseButtonDown(1)) 
                return;
            holding.Drop();
            holding = null;
        }

        private static IPickupable IsPickUp(Collider2D _col)
        {
            if (!_col.TryGetComponent<IPickupable>(out IPickupable _pickupable))
                return null;
            return _pickupable.CanPickUp() ? _pickupable : null;
        }
    }
}