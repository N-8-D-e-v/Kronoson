using UnityEngine;
using Game.General.Utilities.Transformf;

namespace Game.Levels.Objects.Player
{
    public class RotateToPlayer : MonoBehaviour
    {
        //Assignables
        private new Transform transform;

        private void Awake() => transform = GetComponent<Transform>();
        
        private void LateUpdate()
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.GetDirectionToTarget(PlayerData.Transform));
        }
    }
}
