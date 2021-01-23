using UnityEngine;
using Game.General.Utilities.Delegatef;

namespace Game.Levels.Combat.Shooting
{
    public class ChangeLayerAfterSeconds : MonoBehaviour
    {
        //Layer Change
        [SerializeField] private int layer = 9;
        [SerializeField] private float time = 0.25f;

        private void Start() => Delegatef.Invoke(this, ChangeLayer, time);

        private void ChangeLayer() => gameObject.layer = layer;
    }
}