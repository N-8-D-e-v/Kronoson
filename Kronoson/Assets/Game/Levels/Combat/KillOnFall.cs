using UnityEngine;

namespace Game.Levels.Combat
{
    [RequireComponent(typeof(IKillable))]
    public class KillOnFall : MonoBehaviour
    {
        //Assignables
        private new Transform transform;
        private IKillable killable;
        
        //Min Y
        [SerializeField] private float minY = -20f;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            killable = GetComponent<IKillable>();
        }

        private void FixedUpdate()
        {
            if (killable.IsDead())
                return;
            if (transform.position.y < minY)
                killable.Kill();
        } 
    }
}
