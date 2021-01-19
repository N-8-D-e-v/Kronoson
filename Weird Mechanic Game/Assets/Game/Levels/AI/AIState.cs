using UnityEngine;

namespace Game.Levels.AI
{
    public abstract class AIState : MonoBehaviour
    {
        public virtual void LateAwake()
        {
            //OVERRIDE THIS IF NECESSARY
        }

        public abstract bool Condition();

        public abstract void Behaviour();
    }
}