using UnityEngine;
using System.Collections;
using Game.General.TimeManagement;

namespace Game.Levels.Animation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FlashColorAnimation : MonoBehaviour, IAnimation
    {
        //Assignables
        private SpriteRenderer sprite;
        private Timer timer;
        
        //Animation Data
        [SerializeField] private float inLength = 0.1f;
        [SerializeField] private float outLength = 0.15f;
        [SerializeField] private Color flashColor = Color.white;
        private Color startColor;
        
        //Animation
        private Coroutine currentAnimation;

        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            startColor = sprite.color;
        }

        public void Play()
        {
            if (currentAnimation != null)
                StopCoroutine(currentAnimation);
            currentAnimation = StartCoroutine(FlashAnimation());
        }

        private IEnumerator FlashAnimation()
        {
            sprite.color = startColor;
            while()
        }
    }
}