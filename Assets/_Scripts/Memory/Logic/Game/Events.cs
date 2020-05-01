using System;

namespace Memory.Logic
{
    public static partial class Game
    {
        public static event Action GameStarted;
        public static event Action GameFinished;
        public static event Action<int> CardSelected;
        public static event Action<int> PairMatched;
        public static event Action<int, int> ProgressChanged;
        public static event Action<int, int> ResetCards;
        public static event Action HideAllCards;
        public static event Action<TimeSpan> TimeLeftChanged;
    }
}