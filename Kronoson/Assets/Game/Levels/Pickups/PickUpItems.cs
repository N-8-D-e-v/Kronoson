using UnityEngine;

namespace Game.Levels.Pickups
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PickUpItems : MonoBehaviour
    {
        //Assignables
        private Rigidbody2D attachedRigidbody;
        private new Transform transform;

        //Holding
        private IPickupable itemHolding;
                
        //Picking Up
        [Header("Picking Up")]
        [SerializeField] private float pickUpRadius = 1f;
        [SerializeField] private LayerMask pickupableLayers;
        private readonly Collider2D[] itemsInRadius = new Collider2D[10];

        private void Awake()
        {
            attachedRigidbody = GetComponent<Rigidbody2D>();
            transform = GetComponent<Transform>();
        }

        private void Update()
        {
            PickingUp();
            Dropping();
        }

        private void PickingUp()
        {
            PickUp.CheckForItems(transform.position, pickUpRadius, itemsInRadius, pickupableLayers);
            if (!PickUp.FoundItems(itemsInRadius))
                return;

            foreach (Collider2D _item in itemsInRadius)
            {
                if (PickUp.IsPickupableAndCanPickUp(_item, out IPickupable _pickupable))
                    continue;
                if (Drop.IsHoldingItem(itemHolding))
                    Drop.DropItemHolding(ref itemHolding);
                
                PickUp.PickUpItem(_pickupable, attachedRigidbody, out itemHolding);
                return;
            }
        }

        private void Dropping()
        {
            if (Drop.CanDrop(itemHolding))
                Drop.DropItemHolding(ref itemHolding);
        }
    }
}