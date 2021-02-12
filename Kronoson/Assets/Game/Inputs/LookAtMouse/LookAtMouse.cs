using Game.General.Utilities.Mouse;
using Game.General.Utilities.Vectors;
using UnityEngine;

namespace Game.Inputs.LookAtMouse
{
    public class LookAtMouse : MonoBehaviour, ILookAtMouse
    {
        //Public Fields
        public bool Enabled { get; set; } = false;

        //Assignables
        private new Transform transform;

        //Offset
        [SerializeField] private float offset = 0f;
        [SerializeField] private float smoothing = 10f;

        private void Awake() => transform = GetComponent<Transform>();

        private void Update()
        {
            if (!Enabled)
                return;
            
            float _angle = transform.position.GetAngleToMouse(MouseF.MAINCAMERA_Z) + offset;
            Quaternion _rot = Quaternion.AngleAxis(_angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rot, smoothing * Time.deltaTime);
        }
    }
}