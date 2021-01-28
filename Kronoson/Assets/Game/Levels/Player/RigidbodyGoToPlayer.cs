using UnityEngine;

namespace Game.Levels.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RigidbodyGoToPlayer : MonoBehaviour, IGoToPlayer
    {
        //Public Fields
        public bool Enabled { get; set; } = false;
        
        //Assignables
        private Rigidbody2D rb;
        
        //Offset
        [SerializeField] private Vector2 offset = Vector2.up;

        private void Awake() => rb = GetComponent<Rigidbody2D>();

        private void FixedUpdate()
        {
            if (!Enabled)
                return;
            
            rb.MovePosition(PlayerData.GetPlayerPredictedPosition() + (Vector3) offset);
        }
    }
}