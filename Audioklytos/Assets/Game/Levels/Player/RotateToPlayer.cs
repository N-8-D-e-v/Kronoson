using UnityEngine;
using Game.General.Utilities.Vector3f;

namespace Game.Levels.Player
{
    public class RotateToPlayer : MonoBehaviour
    {
        //Assignables
        private new Transform transform;

        private void Awake()
        {
            transform = GetComponent<Transform>();
        }

        private void LateUpdate()
        {
            Vector3 _dir = transform.position.GetDirectionToTarget(PlayerData.GetPlayerPosition());
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _dir);
        }
    }
}