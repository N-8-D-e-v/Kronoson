using System.Collections;

namespace Game.Levels.Combat
{
    public interface IStunnable
    {
        public IEnumerator Stun(float _stunTime);
    }
}