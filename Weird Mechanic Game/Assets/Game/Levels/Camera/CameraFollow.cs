using UnityEngine;
using Game.Levels.General.Player;

namespace Game.Levels.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera), typeof(Rigidbody2D))]
    public class CameraFollow : MonoBehaviour
    {
        //Assignables
        private Rigidbody2D rb;
        
        //Follow Speed
        [Header("Follow Speed")]
        [Range(0f, 1f)] [SerializeField] private float followTime = 0.06f;
        private Vector3 velocity = new Vector3();

        //Bounds
        [Header("Bounds")]
        [SerializeField] private Vector2 xBounds = new Vector2();
        [SerializeField] private Vector2 yBounds = new Vector2();

        //Constants
        private const float Z_POS = -10f;

        private void Awake() => rb = GetComponent<Rigidbody2D>();

        private void FixedUpdate()
        {
            Vector3 _target = PlayerData.Transform.position;
            _target.x = Mathf.Clamp(_target.x, xBounds.x, xBounds.y);
            _target.y = Mathf.Clamp(_target.y, yBounds.x, yBounds.y);
            _target.z = Z_POS;

            rb.MovePosition(Vector3.SmoothDamp(rb.position, _target, ref velocity, followTime));
        }
    }
}
