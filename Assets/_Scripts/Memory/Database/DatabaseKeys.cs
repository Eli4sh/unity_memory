using JetBrains.Annotations;

namespace Memory.Database
{
    public static class DatabaseKeys
    {
        [NotNull]
        public const string GridSizeDatabaseKey = "memory_grid_size";

        [NotNull]
        public const string GameStartedDatabaseKey = "game_started";

        [NotNull]
        public const string LevelDurationDatabaseKey = "level_duration";

        [NotNull]
        public const string CardPairsDatabaseKey = "card_pairs_count";

        [NotNull]
        public const string PairsMatchedDatabaseKey = "pairs_matched";

        [NotNull]
        public const string CurrentlySelectedPairDatabaseKey = "currently_selected_pair";

        [NotNull]
        public const string GameStartedTimeDatabaseKey = "game_started_time";

        [NotNull]
        public const string PreviouslySerlectedPairDatabaseKey = "previous_pair";
        
        [NotNull]
        public static string CardSlotPositionDatabaseKey(int index)
        {
            return $"card_slot_{index}_position";
        }

        [NotNull]
        public static string CardSlotScaleDatabaseKey(int index)
        {
            return $"card_slot_{index}_scale";
        }
    }
}