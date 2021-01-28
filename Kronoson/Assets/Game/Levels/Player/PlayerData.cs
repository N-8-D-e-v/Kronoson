using UnityEngine;
using Game.General.Utilities.Delegates;

namespace Game.Levels.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerData : MonoBehaviour
    {
        //Singleton
        private static PlayerData instance;
        
        //Event
        public static event VoidDelegate OnPlayerDeath;

        //Assignables
        private new static Transform transform;
        private static Rigidbody2D rb;

        //Constants
        public const string PLAYER_TAG = "Player";

        private void Awake()
        {
            if (!instance)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            transform = GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
        }

        public static Vector3 GetPlayerPosition() => transform.position;

        public static Vector3 GetPlayerPredictedPosition() => rb.position + (rb.velocity * Time.fixedDeltaTime);

        public void PlayerDeath() => OnPlayerDeath?.Invoke();
    }
}