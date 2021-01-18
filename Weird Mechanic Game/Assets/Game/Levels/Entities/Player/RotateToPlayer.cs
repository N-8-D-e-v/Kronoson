using UnityEngine;
using Utilities.Transformf;

namespace Game.Levels.General.Player
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
