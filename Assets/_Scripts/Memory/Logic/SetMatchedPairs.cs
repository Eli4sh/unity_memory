using Memory.Database;namespace Memory.Logic{    public static partial class Game    {        private static void SetMatchedPairs(int value)        {            Core.Database.SetDatabaseInt(key: DatabaseKeys.PairsMatchedDatabaseKey, value: value);        }    }}