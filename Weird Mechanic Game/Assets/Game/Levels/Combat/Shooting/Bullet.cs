using UnityEngine;

namespace Game.Levels.Combat
{
    public class Bullet : MonoBehaviour
    {
        //Destroy
        [SerializeField] private float destroyTime = 2f;
        
        private void Awake() => Destroy(gameObject, destroyTime);
        
        private void OnCollisionEnter2D(Collision2D _col) => Destroy(gameObject);
    }
}
