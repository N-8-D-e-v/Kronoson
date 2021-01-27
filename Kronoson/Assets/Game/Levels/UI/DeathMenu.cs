using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using Game.Levels.Player;

namespace Game.Levels.UI
{
    [RequireComponent(typeof(Volume), typeof(CanvasGroup))]
    public class DeathMenu : MonoBehaviour
    {
        //Assignables
        private Volume volume;
        private CanvasGroup canvasGroup;
        
        //Animation
        [SerializeField] private float animationTime;

        private void Awake()
        {
            volume = GetComponent<Volume>();
            canvasGroup = GetComponent<CanvasGroup>();

            PlayerData.OnPlayerDeath += Blur;
            PlayerData.OnPlayerDeath += FadeIn;
        }

        private void Blur() => 
            DOTween.To(() => volume.weight, _x => volume.weight = _x, 1f, animationTime);

        private void FadeIn() => canvasGroup.DOFade(1f, animationTime);
    }
}