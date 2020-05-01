namespace Core.Management
{
    public static class DatabaseKeys
    {
        public const string SoundEnabledDatabaseKey = "sound_enabled";
        public static string LastGameTypeDatabaseKey = "last_game_type";
        public static string LastGameResultDatabaseKey = "last_game_result";

        public static string GameTypeProgressDatabaseKey(string type)
        {
            return $"{type}_progress";
        }
    }
}