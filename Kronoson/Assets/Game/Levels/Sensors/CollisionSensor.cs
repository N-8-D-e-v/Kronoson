using UnityEngine;

namespace Game.Levels.Sensors
{
    public abstract class CollisionSensor : MonoBehaviour
    {
        //Public Fields
        private int overlaps = 0;

        //Tag
        private const string BLOCKING = "Blocking";

        private void OnCollisionEnter2D(Collision2D _col)
        {
            if (_col.collider.CompareTag(BLOCKING))
                overlaps++;
        }

        private void OnCollisionExit2D(Collision2D _col)
        {
            if (_col.collider.CompareTag(BLOCKING))
                overlaps--;
        }

        private void OnTriggerEnter2D(Collider2D _col)
        {
            if (_col.CompareTag(BLOCKING))
                overlaps++;
        }

        private void OnTriggerExit2D(Collider2D _col)
        {
            if (_col.CompareTag(BLOCKING))
                overlaps--;
        }

        protected bool Colliding() => overlaps > 0;
    }
}