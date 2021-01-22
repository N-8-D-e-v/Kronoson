namespace Game.Levels.Pickups
{
    public interface IOnMouseOverlap
    {
        public bool Enabled { set; get; }
        public bool IsMouseDownAndOverlapping();
    }
}