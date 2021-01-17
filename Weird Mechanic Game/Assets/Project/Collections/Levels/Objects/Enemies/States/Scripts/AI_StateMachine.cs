using UnityEngine;
using Utilities.Transformf;

[RequireComponent(typeof(Animator))]
public class AI_StateMachine : MonoBehaviour
{
    //Assignables
    private Animator animator;
    
    //States (DRAG THESE AS CHILDREN UNDER THE AI IN ORDER OF PRIORITY)
    private AI_State[] states;

    //Animation
    private const string STATE = "state";

    private void Awake()
    {
        states = transform.InitializeHierarchy<AI_State>();
        animator = GetComponent<Animator>();

        for (int i = 0; i < states.Length; i++)
            states[i].LateAwake();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < states.Length; i++)
        {
            AI_State _state = states[i];
            if (_state.Condition())
            {
                _state.Behaviour();
                animator.SetInteger(STATE, i);
                return;
            }
        }

    }
}
