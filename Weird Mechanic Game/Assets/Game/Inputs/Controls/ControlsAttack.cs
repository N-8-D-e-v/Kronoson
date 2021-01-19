using UnityEngine;
using Game.Levels.Combat;

namespace Game.Inputs.Controls
{
    [RequireComponent(typeof(IAttack))] 
    public class ControlsAttack : Controls
    {
        //Assignables
        private IAttack attack;

        private void Awake() => attack = GetComponent<Shooting>();

        protected override void Enabled() => attack.InputAttack = Input.GetMouseButtonDown(0);

        protected override void NotEnabled() => attack.InputAttack = false;
    }
}