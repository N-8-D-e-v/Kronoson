using UnityEngine;

namespace Game.Levels.Combat
{
    [RequireComponent((typeof(IKillable)))]
    public class TakeDamage : MonoBehaviour, IDamageable
    {
        //Assignables
        private IKillable killable;
        
        //Health
        [SerializeField] private int startHealth = 100;
        private int health = 0;

        private void Awake()
        {
            killable = GetComponent<IKillable>();
            health = startHealth;
        }

        public int GetHealth() => health;

        public void Damage(int _damage)
        {
            health = Mathf.Max(0, health - _damage);
            if (health <= 0)
                killable.Kill();
        }
    }
}