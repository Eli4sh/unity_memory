using UnityEngine;namespace Memory.Logic{    public static partial class Game    {        public static void SetCardSlotScale(int index, Vector3 value)        {            Core.Database.SetDatabaseVector3(Database.DatabaseKeys.CardSlotScaleDatabaseKey(index), value);        }    }}