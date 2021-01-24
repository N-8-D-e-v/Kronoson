namespace Game.Levels.Combat
{
    public interface IKillable
    {
        public void Kill();

        public bool IsDead();
    }
}