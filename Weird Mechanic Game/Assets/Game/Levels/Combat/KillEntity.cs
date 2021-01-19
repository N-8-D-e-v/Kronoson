using UnityEngine;

namespace Game.Levels.Combat
{
    public class KillEntity : MonoBehaviour, IKillable
    {
        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}