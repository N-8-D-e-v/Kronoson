using UnityEngine;

namespace Game.Levels.Pickups
{
    public static class Drop
    {
        public static bool IsHoldingItem(IPickupable _itemHolding) => _itemHolding != null;
        public static bool CanDrop(IPickupable _itemHolding) => _itemHolding != null && Input.GetMouseButtonDown(1);

        public static void DropItemHolding(ref IPickupable _itemHolding)
        {
            _itemHolding.Drop();
            _itemHolding = null;
        }
    }
}