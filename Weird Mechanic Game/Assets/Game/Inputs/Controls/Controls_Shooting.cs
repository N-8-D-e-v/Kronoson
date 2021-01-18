using UnityEngine;

namespace Game.Inputs.Controls
{
    [RequireComponent(typeof(Shooting))]
    public class Controls_Shooting : Controls
    {
        //Assignables
        private Shooting shooting;

        private void Awake() => shooting = GetComponent<Shooting>();

        protected override void Enabled()
        {
            shooting.Input_Shoot = Input.GetMouseButtonDown(0);
        }

        protected override void NotEnabled()
        {
            shooting.Input_Shoot = false;
        }
    }
}
