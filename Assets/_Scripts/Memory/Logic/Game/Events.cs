using System;
using Memory.Enums;

namespace Memory.Logic
{
    public static partial class Game
    {
        public static event Action GameStarted;
        public static event Action<CompletenessType> GameFinished;
        public static event Action<int> CardSelected;
        public static event Action CardSelectionEnabled;
        public static event Action CardSelectionDisabled;
        public static event Action<int> PairMatched;
        public static event Action<int, int> ProgressChanged;
        public static event Action<int, int> ResetCards;
        public static event Action HideAllCards;
        public static event Action<TimeSpan> TimeLeftChanged;
    }
}