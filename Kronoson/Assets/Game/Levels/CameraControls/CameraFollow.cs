using UnityEngine;
using Game.Levels.Player;

namespace Game.Levels.CameraControls
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CameraFollow : MonoBehaviour
    {
        //Assignables
        private Rigidbody2D rb;

        //Follow Speed
        [Header("Follow Speed")] 
        [Range(0f, 1f)] [SerializeField]
        private float followTime = 0.06f;
        private Vector3 velocity;

        //Bounds
        [Header("Bounds")]
        [SerializeField] private CameraBounds bounds;
        
        //Dead Zone
        [Header("Dead Zone")]
        [SerializeField] private CameraBounds deadZone;

        //Constants
        private const float Z_POS = -10f;

        private void Awake() => rb = GetComponent<Rigidbody2D>();

        private void FixedUpdate()
        {
            Vector3 _target = PlayerData.GetPlayerPosition();
            _target.z = Z_POS;
            
            if (deadZone.UseBounds)
            {
                Vector3 _pos = rb.position;
                if (_target.x < _pos.x + deadZone.MaxX && _target.x > _pos.x + deadZone.MinX)
                    _target.x = _pos.x;
                if (_target.y < _pos.y + deadZone.MaxY && _target.y > _pos.y + deadZone.MinY)
                    _target.y = _pos.y;
            }
            
            if (bounds.UseBounds)
            {
                _target.x = Mathf.Clamp(_target.x, bounds.MinX, bounds.MaxX);
                _target.y = Mathf.Clamp(_target.y, bounds.MinY, bounds.MaxY);
            }

            rb.MovePosition(Vector3.SmoothDamp(rb.position, _target, ref velocity, followTime));
        }
    }


}