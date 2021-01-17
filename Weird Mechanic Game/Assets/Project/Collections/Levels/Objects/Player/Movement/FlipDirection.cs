using UnityEngine;
using Utilities.Transformf;

[RequireComponent(typeof(Movement))]
public class FlipDirection : MonoBehaviour
{
    //Assignables
    private Movement movement;

    private void Awake() => movement = GetComponent<Movement>();

    private void Update() => transform.Flip(movement.Input_Axis);
}
