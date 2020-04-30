using JetBrains.Annotations;

namespace Memory.Database
{
    public static partial class DatabaseKeys
    {
        [NotNull]
        public static string GameStartedDatabaseKey = "game_started";

        [NotNull]
        public static string CardIndexDatabaseKey(int instanceId) => $"card_index_{instanceId}";

        [NotNull]
        public static string LevelDurationDatabaseKey = "level_duration";

        [NotNull]
        public static string CardPairsDatabaseKey = "card_pairs_count";
    }
}