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
        
        //Picking up and dropping
        [SerializeField] private PickUp pickUp;
        private readonly Drop drop = new Drop();

        private void Awake()
        {
            attachedRigidbody = GetComponent<Rigidbody2D>();
            transform = GetComponent<Transform>();
        }

        private void Update() => PickingUp();

        private void PickingUp()
        {
            if (drop.CanDrop(itemHolding))
                drop.DropItemHolding(ref itemHolding);

            pickUp.CheckForItems(transform.position);
            if (pickUp.ItemsInRadius.Length == 0)
                return;
            foreach (Collider2D _item in pickUp.ItemsInRadius)
            {
                //Non alloc circle check may not populate whole array
                if (!_item)
                    break;
                if (!pickUp.IsPickupableAndCanPickUp(_item, out IPickupable _pickupable))
                    continue;
                if (drop.IsHoldingItem(itemHolding))
                    drop.DropItemHolding(ref itemHolding);
                
                pickUp.PickUpItem(out itemHolding, _pickupable);
                break;
            }
        }

        public void Drop()
        {
            if (drop.IsHoldingItem(itemHolding))
                drop.DropItemHolding(ref itemHolding);
        }
    }
}