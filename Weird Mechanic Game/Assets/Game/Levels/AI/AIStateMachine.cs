using System;
using UnityEngine;
using Game.General.Utilities.Transformf;

namespace Game.Levels.AI
{
    [RequireComponent(typeof(Animator))]
    public class AIStateMachine : MonoBehaviour
    {
        //Assignables
        private Animator animator;

        //States (DRAG THESE AS CHILDREN UNDER THE AI IN ORDER OF PRIORITY)
        private AIState[] states;

        //Animation
        private static readonly int STATE = Animator.StringToHash("state");

        private void Awake()
        {
            states = transform.InitializeHierarchy<AIState>();
            animator = GetComponent<Animator>();

            foreach (AIState _state in states)
                _state.LateAwake();
        }

        private void FixedUpdate()
        {
            for (int _i = 0; _i < states.Length; _i++)
            {
                AIState _state = states[_i];
                if (!_state.Condition())
                    continue;
                _state.Behaviour();
                animator.SetInteger(STATE, _i);
                return;
            }
        }
    }
}