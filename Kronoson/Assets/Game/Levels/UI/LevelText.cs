using UnityEngine;
using TMPro;

namespace Game.Levels.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]   
    public class LevelText : MonoBehaviour
    {
        //Assignables
        private TextMeshProUGUI levelText;

        private void Awake() => levelText = GetComponent<TextMeshProUGUI>();

        private void Update() => levelText.text = $"LEVEL {LevelData.GetLevel().ToString()}";
    }
}