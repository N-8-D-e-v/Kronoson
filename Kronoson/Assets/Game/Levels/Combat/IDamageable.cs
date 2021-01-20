namespace Game.Levels.Combat
{
    public interface IDamageable
    {
        public void Damage(int _damage);

        public int GetHealth();
    }
}