using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    public static partial class Database
    {
        public static int? GetDatabaseInt(
            [NotNull] string key)
        {
            if (!PlayerPrefs.HasKey(key: key)) return null;

            return PlayerPrefs.GetInt(key: key);
        }
    }
}