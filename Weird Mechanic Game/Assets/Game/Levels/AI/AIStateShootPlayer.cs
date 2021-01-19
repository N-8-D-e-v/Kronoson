using UnityEngine;
using Game.Levels.Combat;

namespace Game.Levels.AI
{
    [RequireComponent(typeof(Shooting))]
    public class AIStateShootPlayer : AIStateFollowPlayer
    {
        //Assignables
        private Shooting shooting;

        public override void LateAwake()
        {
            base.LateAwake();
            shooting = GetComponent<Shooting>();
        }

        public override void Behaviour()
        {
            base.Behaviour();
            shooting.Input_Shoot = true;
        }
    }
}