using UnityEngine;
using Utilities.Transformf;

public class RotateToPlayer : MonoBehaviour
{
    //Assignables
    private new Transform transform;

    private void Awake() => transform = GetComponent<Transform>();
    
    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.GetDirectionToTarget(Player.Transform));
    }
}
