using UnityEngine;

namespace Game.Levels.Objects.Player
{
    public class GoToPlayer : MonoBehaviour
    {
        //Offset
        [SerializeField] private Vector3 offset;
        
        private void LateUpdate() => transform.position = PlayerData.Transform.position + offset;
    }
}
