using System.Collections;
using Game.General.Audio;
using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    [RequireComponent(typeof(Collider2D))]
    public class Explosion : Damage
    {
        //Assignables
        private Collider2D col;
        
        //Explosion
        [Header("Explosion")]
        [SerializeField] private float explosionLength = 0.6f;

        protected override void Awake()
        {
            base.Awake();
            col = GetComponent<Collider2D>();
        }

        private IEnumerator Start()
        {
            SoundManager.PlaySound(SoundType.GrenadeLauncherGunExplode);
            yield return new WaitForSeconds(explosionLength);
            col.enabled = false;
        }
        
        private void OnTriggerEnter2D(Collider2D _col) => DealDamage(_col);
    }
}