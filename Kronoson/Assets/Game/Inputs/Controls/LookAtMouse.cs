using UnityEngine;
using Game.General.Utilities.Vector3f;

namespace Game.Inputs.Controls
{
    public class LookAtMouse : MonoBehaviour
    {
        //Assignables
        private new Transform transform;

        //Offset
        [SerializeField] private float offset = 0f;
        [SerializeField] private float smoothing = 10f;

        private void Awake()
        {
            transform = GetComponent<Transform>();
        }

        private void Update()
        {
            Quaternion _rot = Quaternion.AngleAxis(transform.position.GetAngleToMouse(-10) + offset, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rot, smoothing * Time.deltaTime);
        }
    }
}