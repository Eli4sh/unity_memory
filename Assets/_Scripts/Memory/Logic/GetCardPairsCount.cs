using Memory.Database;namespace Memory.Logic{    public static partial class Game    {        private static int GetCardPairsCount()        {            return Core.Database.GetDatabaseInt(key: DatabaseKeys.CardPairsDatabaseKey) ?? -1;        }    }}