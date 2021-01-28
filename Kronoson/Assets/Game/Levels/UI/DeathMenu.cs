using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using Game.Levels.Player;

namespace Game.Levels.UI
{
    [RequireComponent(typeof(Volume))]
    [RequireComponent(typeof(CanvasGroup), typeof(GraphicsGroup))]
    public class DeathMenu : MonoBehaviour
    {
        //Assignables
        private Volume volume;
        private CanvasGroup canvasGroup;
        private GraphicsGroup graphicsGroup;
        
        //Animation
        [SerializeField] private float animationTime;

        private void Awake()
        {
            volume = GetComponent<Volume>();
            canvasGroup = GetComponent<CanvasGroup>();
            graphicsGroup = GetComponent<GraphicsGroup>();
            
            PlayerData.OnPlayerDeath += FadeIn;
        }

        private void FadeIn()
        {
            canvasGroup.DOFade(1f, animationTime);
            DOTween.To
            (() => volume.weight, 
                _x => volume.weight = _x, 
                1f, animationTime);
            DOTween.To
            (() => graphicsGroup.Scale,
            _x => graphicsGroup.Scale = _x, 
            1f, animationTime / 3f);

        }
    }
}