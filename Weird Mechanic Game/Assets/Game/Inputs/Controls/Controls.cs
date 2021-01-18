using UnityEngine;

namespace Game.Inputs.Controls
{
    public abstract class Controls : MonoBehaviour
    {
        //Public Fields
        public bool IsEnabled = true;

        private void Update()
        {
            if (IsEnabled)
                Enabled();
            else
                NotEnabled();
        }

        protected abstract void Enabled();

        protected abstract void NotEnabled();
    }
}
