using System;

namespace Memory.Logic
{
    public static partial class Game
    {
        public static event Action GameStarted;
        //TODO: Add game result as Action parameter 
        public static event Action GameFinished;
        public static event Action<int> CardSelected;
        public static event Action<int> LevelDurationSet;
        public static event Action<int> TimeLeftChanged;
    }
}