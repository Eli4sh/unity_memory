using UnityEngine;namespace Memory.Logic{    public static partial class Game     {        public static void SetCardSlotPosition(int index, Vector3 value)        {            Core.Database.SetDatabaseVector3(Database.DatabaseKeys.CardSlotPositionDatabaseKey(index), value);        }    }}