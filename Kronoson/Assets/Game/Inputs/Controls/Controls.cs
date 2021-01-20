using UnityEngine;

namespace Game.Inputs.Controls
{
    public abstract class Controls : MonoBehaviour
    {
        //Public Fields
        [SerializeField] private bool isEnabled = true;

        private void Update()
        {
            if (isEnabled)
                Enabled();
            else
                NotEnabled();
        }

        protected abstract void Enabled();

        protected abstract void NotEnabled();
    }
}