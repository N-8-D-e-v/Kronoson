using UnityEngine;

namespace Game.Levels.Objects.Player
{
    public class GoToPlayer : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        
        //Offset
        [SerializeField] private Vector3 offset;

        private void Awake() => transform = GetComponent<Transform>();
        
        private void LateUpdate() => transform.position = PlayerData.GetPlayerPosition() + offset;
    }
}
