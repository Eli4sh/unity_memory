using JetBrains.Annotations;

namespace Memory.Database
{
    public static class DatabaseKeys
    {
        [NotNull]
        public const string GameStartedDatabaseKey = "game_started";

        [NotNull]
        public const string LevelDurationDatabaseKey = "level_duration";

        [NotNull]
        public const string CardPairsDatabaseKey = "card_pairs_count";

        [NotNull]
        public static string CardIndexDatabaseKey(int instanceId) => $"card_index_{instanceId}";
    }
}