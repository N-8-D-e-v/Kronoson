using UnityEngine;

namespace Game.Levels.Pickups
{
    [RequireComponent(typeof(Animator), typeof(Collider2D))]
    public class HighlightOnMouseOverlap : MonoBehaviour, IOnMouseOverlap
    {
        //Public Fields
        public bool Enabled { set; get; } = true;
        
        //Assignables
        private Animator animator;
        
        //Overlapping
        private bool isMouseOverlapping = false;

        //Animation
        private static readonly int HIGHLIGHT = Animator.StringToHash("highlight");

        private void Awake() => animator = GetComponent<Animator>();

        private void Update() => animator.SetBool(HIGHLIGHT, Enabled && isMouseOverlapping);

        private void OnMouseEnter() => isMouseOverlapping = true;

        private void OnMouseExit() => isMouseOverlapping = false;

        public bool IsMouseDownAndOverlapping() => Enabled && Input.GetMouseButtonDown(1) && isMouseOverlapping;
        
    }
}