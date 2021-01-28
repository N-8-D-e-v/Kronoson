using UnityEngine;

namespace Game.Levels.Pickups
{
    public class Drop
    {
        public bool IsHoldingItem(IPickupable _itemHolding) => _itemHolding != null;
        public bool CanDrop(IPickupable _itemHolding) => _itemHolding != null && Input.GetMouseButtonDown(1);

        public void DropItemHolding(ref IPickupable _itemHolding)
        {
            _itemHolding.Drop();
            _itemHolding = null;
        }
    }
}