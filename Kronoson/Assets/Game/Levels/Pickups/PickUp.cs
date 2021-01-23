using UnityEngine;

namespace Game.Levels.Pickups
{
    public static class PickUp
    {
        public static void CheckForItems(Vector3 _pos, float _radius, Collider2D[] _results, LayerMask _layers)
        {
            Physics2D.OverlapCircleNonAlloc(_pos, _radius, _results, _layers);
        }

        public static bool FoundItems(Collider2D[] _itemsInRadius)
        {
            return _itemsInRadius.Length > 0;
        }

        public static bool IsPickupableAndCanPickUp(Collider2D _col, out IPickupable _result)
        {
            bool _isPickupable = _col.TryGetComponent<IPickupable>(out IPickupable _pickupable);
            _result = _isPickupable && _pickupable.CanPickUp() ? _pickupable : null;
            return _isPickupable && _pickupable.CanPickUp();
        }

        public static void PickUpItem(IPickupable _pickupable, Rigidbody2D _attachedRigidbody, out IPickupable _itemHolding)
        {
            _pickupable.PickUp(_attachedRigidbody);
            _itemHolding = _pickupable;
        }
    }
}