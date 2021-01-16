using UnityEngine;

[RequireComponent(typeof(Movement), typeof(Jumping))]
public class Controls_Movement : MonoBehaviour
{
    //Public Fields
    public bool IsEnabled = true;

    //Assignables
    private Movement movement;
    private Jumping jumping;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        jumping = GetComponent<Jumping>();
    }
    
    private void Update()
    {
        if (!IsEnabled)
        {
            movement.Input_Axis = 0f;
            jumping.Input_Up = false;
        }
        else
        {
            movement.Input_Axis = Input.GetAxisRaw("Horizontal");
            jumping.Input_Up = Input.GetAxisRaw("Vertical") > 0;
        }
    }
}
