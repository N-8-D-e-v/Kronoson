using UnityEngine;

public class GoToPlayerPosition : MonoBehaviour
{
    //Offset
    [SerializeField] private Vector3 offset;
    
    private void LateUpdate()
    {
        transform.position = Player.Transform.position + offset;
    }
}
