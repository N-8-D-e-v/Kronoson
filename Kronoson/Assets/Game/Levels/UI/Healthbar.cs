using Game.Levels.Combat;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Levels.UI
{
    [RequireComponent(typeof(Slider))]
    public class Healthbar : MonoBehaviour
    {
        //Assignables
        [Header("Assignables")]
        [Tooltip("This is an interface so it will be a little wack to assign try locking one inspector and assigning with another)")]
        [SerializeField] private Component damageable;
        private Slider healthbar;
        
        //Smoothing
        [Header("Smoothing")]
        [SerializeField] private float smoothingTime = 0.1f;
        private float velocity = 0f;

        private void OnValidate()
        {
            if (!(damageable is IDamageable))
                damageable = null;
        }

        private void Awake() => healthbar = GetComponent<Slider>();

        private void Start()
        {
            healthbar.maxValue = GetDamageable().GetHealth();
            healthbar.value = healthbar.maxValue;
        }

        private void Update()
        {
            float _target = GetDamageable().GetHealth();
            float _current = healthbar.value;
            float _health = Mathf.SmoothDamp(_current, _target, ref velocity, smoothingTime);
            healthbar.value = _health;
        }

        private IDamageable GetDamageable() => damageable as IDamageable;
    }
}