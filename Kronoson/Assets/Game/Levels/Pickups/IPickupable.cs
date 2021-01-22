using UnityEngine;

namespace Game.Levels.Pickups
{
    public interface IPickupable
    {
        public bool CanPickUp();
        
        public void PickUp(Rigidbody2D _pickUp);
        
        public void Drop();
    }
}