using Game.Levels.Combat;
using Game.General.TimeManagement;
using UnityEngine;

namespace Game.Levels.AI
{
    public class AIStateAttackPlayerMultiple : AIStateFollowPlayer
    {
        //Assignables
        private IAttack[] attacks;
        private Timer[] attackTimers;
        
        //Attacking
        [Header("Attacking")]
        [SerializeField] private float attackIncrements = 0.2f;
        [SerializeField] private float attackRate = 1f;

        public override void LateAwake()
        {
            base.LateAwake();
            attacks = GetComponentsInChildren<IAttack>();
            attackTimers = new Timer[attacks.Length];
            for (int _i = 0; _i < attackTimers.Length; _i++)
                attackTimers[_i] = new Timer(attackRate + (attackIncrements * _i));
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            foreach (IAttack _attack in attacks)
                _attack.InputAttack = false;
        }

        public override void Behaviour()
        {
            base.Behaviour();
            for (int _i = 0; _i < attackTimers.Length; _i++)
            {
                attackTimers[_i].Tick(Time.deltaTime);
                if (attackTimers[_i].Time != 0) 
                    continue;
                attacks[_i].InputAttack = true;
                attackTimers[_i].Time = attackRate;
            }
        }
    }
}