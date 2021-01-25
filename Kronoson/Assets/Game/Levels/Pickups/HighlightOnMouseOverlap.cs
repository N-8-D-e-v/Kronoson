using UnityEngine;
using Game.General.Utilities.Mouse;

namespace Game.Levels.Pickups
{
    [RequireComponent(typeof(Animator), typeof(Collider2D))]
    public class HighlightOnMouseOverlap : MonoBehaviour, IOnMouseOverlap
    {
        //Public Fields
        public bool Enabled { set; get; } = true;
        
        //Assignables
        [SerializeField] private new Collider2D collider;
        private Animator animator;
        private Camera mainCamera;
        
        //Overlapping
        private bool isMouseOverlapping = false;

        //Animation
        private static readonly int HIGHLIGHT = Animator.StringToHash("highlight");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            mainCamera = Camera.main;
        }

        private void Update()
        {
            Vector3 _mousePos = mainCamera.ScreenToWorldPoint(MouseF.GetMousePosition());
            isMouseOverlapping = collider.OverlapPoint(_mousePos);
            animator.SetBool(HIGHLIGHT, Enabled && isMouseOverlapping);
        }

        public bool IsMouseDownAndOverlapping() => Enabled && Input.GetMouseButtonDown(1) && isMouseOverlapping;
        
    }
}