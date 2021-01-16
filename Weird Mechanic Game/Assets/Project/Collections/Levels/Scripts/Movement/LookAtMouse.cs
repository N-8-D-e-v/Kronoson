using UnityEngine;
using Utilities.Transformf;

public class LookAtMouse : MonoBehaviour
{
    //Offset
    [SerializeField] private float offset = 0f;
    [SerializeField] private float smoothing = 10f;
    
    private void Update()
    {
        Quaternion _rot = Quaternion.AngleAxis(transform.GetAngleToMouse(-10) + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, _rot, smoothing * Time.deltaTime);
    }
}
