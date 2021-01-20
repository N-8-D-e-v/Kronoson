using UnityEngine;

namespace Game.Levels.AI
{
    public abstract class AIState : MonoBehaviour
    {
        public virtual void LateAwake() { }

        protected abstract void OnDisable();

        public abstract bool Condition();

        public abstract void Behaviour();
    }
}