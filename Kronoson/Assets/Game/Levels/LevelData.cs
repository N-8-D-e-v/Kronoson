using Game.General.Utilities.Delegates;

namespace Game.Levels
{
    public static class LevelData
    {
        //Event
        public static event VoidDelegate OnGameStart;
        public static event VoidDelegate OnGameStop;
        
        //Level
        private static int level = 1;

        public static void StartGame() => OnGameStart?.Invoke(); 
        
        public static void StopGame() => OnGameStop?.Invoke();

        public static void NextLevel() => level += 1;

        public static int GetLevel() => level;

        public static void Reset() => level = 1;
    }
}