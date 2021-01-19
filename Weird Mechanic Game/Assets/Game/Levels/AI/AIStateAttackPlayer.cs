using UnityEngine;
using Game.Levels.Combat;

namespace Game.Levels.AI
{
    [RequireComponent(typeof(IAttack))]
    public class AIStateAttackPlayer : AIStateFollowPlayer
    {
        //Assignables
        private IAttack attack;

        public override void LateAwake()
        {
            base.LateAwake();
            attack = GetComponent<Shooting>();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            attack.InputAttack = false;
        }

        public override void Behaviour()
        {
            base.Behaviour();
            attack.InputAttack = true;
        }
    }
}