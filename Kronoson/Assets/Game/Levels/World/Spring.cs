using UnityEngine;

namespace Game.Levels.World
{
    public class Spring : MonoBehaviour
    {
        //Bounce
        [SerializeField] private float bounce = 100f;

        private void OnTriggerEnter2D(Collider2D _col)
        {
            if (!_col.TryGetComponent<Rigidbody2D>(out Rigidbody2D _rb))
                return;
            _rb.velocity = new Vector2(_rb.velocity.x, bounce);
        }
    }
}