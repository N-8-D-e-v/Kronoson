using UnityEditor;
using Game.Levels.CameraControls;

namespace Game.Editor
{
    [CustomEditor(typeof(CameraBounds))]
    public class CameraFollowBoundsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CameraBounds _bounds = target as CameraBounds;
            if (!_bounds.UseBounds) 
                return;
            _bounds.MinX = EditorGUILayout.FloatField("Min X", _bounds.MinX);
            _bounds.MaxX = EditorGUILayout.FloatField("Max X", _bounds.MaxX);
            _bounds.MinY = EditorGUILayout.FloatField("Min Y", _bounds.MinY);
            _bounds.MaxY = EditorGUILayout.FloatField("Max Y", _bounds.MaxY);
        }
    }
}