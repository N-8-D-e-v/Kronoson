using UnityEngine;

namespace Game.Levels.Pickups
{
    public interface IPickupable
    {
        public bool CanPickUp();
        
        public void PickUp();
        
        public void Drop();
    }
}