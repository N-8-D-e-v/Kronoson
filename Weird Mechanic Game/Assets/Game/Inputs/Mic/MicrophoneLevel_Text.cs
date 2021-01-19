using UnityEngine;
using TMPro;

namespace Game.Inputs.Mic
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MicrophoneLevel_Text : MonoBehaviour
    {
        //Assignables
        private TextMeshProUGUI micLevelText;

        private void Awake() => micLevelText = GetComponent<TextMeshProUGUI>();
        
        private void Update() => micLevelText.text = MicrophoneData.MicrophoneLevel.ToString();
    }
}
