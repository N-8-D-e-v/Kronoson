using Game.General.Utilities.Delegates;
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

        private void Awake()
        {
            attachedRigidbody = GetComponent<Rigidbody2D>();
            transform = GetComponent<Transform>();
        }

        private void Update() => PickingUp();

        private void PickingUp()
        {
            if (Pickups.Drop.CanDrop(itemHolding))
            {
                Pickups.Drop.DropItemHolding(ref itemHolding);
                return;
            }

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
                pickUp.PickUpItem(out itemHolding, _pickupable);
                break;
            }
        }

        public void Drop()
        {
            if (itemHolding == null) 
                return;
            Pickups.Drop.DropItemHolding(ref itemHolding);
        }
    }
}