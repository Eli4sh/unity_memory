namespace Memory.Logic{    public static partial class Game     {        public static void SetCardPairsCount(int value)        {            Core.Database.SetDatabaseInt(key: Database.DatabaseKeys.CardPairsDatabaseKey, value);        }    }}