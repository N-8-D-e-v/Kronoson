namespace Game.Levels
{
    public static class LevelData
    {
        //Level
        private static int level = 1;

        public static void NextLevel() => level += 1;

        public static int GetLevel() => level;

        public static void Reset() => level = 1;
    }
}