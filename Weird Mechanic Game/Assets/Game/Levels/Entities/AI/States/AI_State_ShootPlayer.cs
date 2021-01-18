using UnityEngine;

namespace Game.Levels.General.AI.States
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

        public override bool Condition()
        {
            return base.Condition();
        }

        public override void Behaviour()
        {
            base.Behaviour();
            shooting.Input_Shoot = true;
        }
    }
}
