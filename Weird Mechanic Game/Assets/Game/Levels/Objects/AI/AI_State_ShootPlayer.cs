using UnityEngine;
using Game.Levels.Combat;

namespace Game.Levels.Objects.AI
{
    [RequireComponent(typeof(Shooting))]
    public class AI_State_ShootPlayer : AI_State_FollowPlayer
    {
        //Assignables
        private Shooting shooting;

        public override void LateAwake()
        {
            base.LateAwake();
            shooting = GetComponent<Shooting>();
        }

        public override bool Condition() => base.Condition();

        public override void Behaviour()
        {
            base.Behaviour();
            shooting.Input_Shoot = true;
        }
    }
}