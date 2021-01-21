using Game.Levels.Combat.Shooting;
using UnityEditor;

namespace Game.Editor
{
    [UnityEditor.CustomEditor(typeof(Gun))]
    public class GunEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            Gun _gun = target as Gun;
            if (_gun.Shots > 1)
                EditorGUILayout.Slider("Spread", _gun.Spread, 0f, 180f);
        }
    }
}