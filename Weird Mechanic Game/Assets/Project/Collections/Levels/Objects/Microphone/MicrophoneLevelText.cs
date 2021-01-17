using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MicrophoneLevelText : MonoBehaviour
{
    //Assignables
    private TextMeshProUGUI micLevelText;

    private void Awake() => micLevelText = GetComponent<TextMeshProUGUI>();
    
    private void Update()
    {
        micLevelText.text = MicrophoneData.MicrophoneLevel.ToString();
    }
}
