using UnityEngine;

namespace Game.Levels.Sensors
{
    [RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
    public abstract class CollisionSensor : MonoBehaviour
    {
        //Public Fields
        private int Overlaps = 0;

        //Tag
        private const string BLOCKING = "Blocking";

        private void OnCollisionEnter2D(Collision2D _col)
        {
            if (_col.collider.CompareTag(BLOCKING))
                Overlaps++;
        }

        private void OnCollisionExit2D(Collision2D _col)
        {
            if (_col.collider.CompareTag(BLOCKING))
                Overlaps--;
        }

        private void OnTriggerEnter2D(Collider2D _col)
        {
            if (_col.CompareTag(BLOCKING))
                Overlaps++;
        }

        private void OnTriggerExit2D(Collider2D _col)
        {
            if (_col.CompareTag(BLOCKING))
                Overlaps--;
        }

        public bool Colliding()
        {
            return Overlaps > 0;
        }
    }
}