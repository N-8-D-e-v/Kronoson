using Game.General.Audio;
using Game.General.Utilities.Delegates;
using UnityEngine;

namespace Game.Levels.Pickups
{
    [System.Serializable]
    public class PickUp
    {
        //Picking Up
        [SerializeField] private float pickUpRadius = 1f;
        [SerializeField] private LayerMask pickupableLayers;
        public readonly Collider2D[] ItemsInRadius = new Collider2D[10];
        
        public bool CheckForItems(Vector3 _pos)
        {
            Physics2D.OverlapCircleNonAlloc(_pos, pickUpRadius, ItemsInRadius, pickupableLayers);
            return ItemsInRadius.Length > 0;
        }

        public bool IsPickupableAndCanPickUp(Collider2D _col, out IPickupable _result)
        {
            bool _isPickupable = _col.TryGetComponent<IPickupable>(out IPickupable _pickupable);
            _result = _isPickupable && _pickupable.CanPickUp() ? _pickupable : null;
            return _isPickupable && _pickupable.CanPickUp();
        }

        public void PickUpItem(out IPickupable _itemHolding, IPickupable _pickupable)
        {
            _itemHolding = _pickupable;
            SoundManager.PlaySound(SoundType.PickUp);
            _itemHolding.PickUp();
        }
    }
}