using UnityEngine;
using Game.Levels.Combat;

namespace Game.Inputs.Controls
{
    [RequireComponent(typeof(IAttack))] 
    public class ControlsAttack : Controls
    {
        //Assignables
        private IAttack attack;

        private void Awake() => attack = GetComponent<IAttack>();

        protected override void Enabled() => 
            attack.InputAttack = attack.IsAutomatic() ? Input.GetMouseButton(0) : Input.GetMouseButtonDown(0);

        protected override void NotEnabled() => attack.InputAttack = false;
    }
}