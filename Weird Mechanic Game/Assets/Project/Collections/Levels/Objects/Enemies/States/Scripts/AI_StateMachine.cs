using UnityEngine;
using Utilities.Transformf;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class AI_StateMachine : MonoBehaviour
{
    //Assignables
    private Rigidbody2D rb;
    private Animator animator;
    
    //States (DRAG THESE AS CHILDREN UNDER THE AI IN ORDER OF PRIORITY)
    private AI_State[] states;

    //Animation
    private const string STATE = "state";

    private void Awake()
    {
        states = transform.InitializeHierarchy<AI_State>();
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        for (int i = 0; i < states.Length; i++)
        {
            states[i].Rigidbody = rb;
            states[i].Transform = transform;
        }

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
