using UnityEngine;
using Game.Levels.Player;
using Game.General.Utilities.Mouse;

namespace Game.Levels.CameraControls
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CameraFollow : MonoBehaviour
    {
        //Assignables
        private Rigidbody2D rb;
        
        //Target
        private Vector3 target;
        private bool isOn = true;

        //Follow Speed
        [Header("Follow Speed")] 
        [Range(0f, 1f)] [SerializeField]
        private float followTime = 0.06f;
        private Vector3 velocity;

        //Bounds
        [Header("Bounds")]
        [SerializeField] private CameraBounds bounds;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            PlayerData.OnPlayerDeath += TurnOff;
        }

        private void FixedUpdate()
        {
            if (!isOn)
                return;
            
            Vector3 _target = PlayerData.GetPlayerPosition();
            Vector3 _pos = rb.position;
            _target.z = MouseF.MAINCAMERA_Z;
            if (bounds.UseBounds)
            {
                _target.x = Mathf.Clamp(_target.x, bounds.MinX, bounds.MaxX);
                _target.y = Mathf.Clamp(_target.y, bounds.MinY, bounds.MaxY);
            }
            target = _target;

            rb.MovePosition(Vector3.SmoothDamp(_pos, target, ref velocity, followTime));
        }

        private void TurnOff() => isOn = false;
    }


}