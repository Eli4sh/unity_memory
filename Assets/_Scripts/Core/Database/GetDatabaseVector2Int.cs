using JetBrains.Annotations;using UnityEngine;namespace Core{    public static partial class Database    {        public static Vector2Int GetDatabaseVector2Int([NotNull] string key)        {            int x = PlayerPrefs.GetInt($"{key}_x", -1);            int y = PlayerPrefs.GetInt($"{key}_y", -1);            return new Vector2Int(x, y);        }    }}