using UnityEngine;

namespace Game.Levels.Player
{
    public class GoToPlayer : MonoBehaviour, IGoToPlayer
    {
        //Public Fields
        public bool Enabled { get; set; } = false;

        //Assignables
        private new Transform transform;

        //Offset
        [SerializeField] private Vector3 offset;

        private void Awake() => transform = GetComponent<Transform>();

        private void LateUpdate()
        {
            if (!Enabled)
                return;
            transform.position = PlayerData.GetPlayerPosition() + offset;
        }
    }
}