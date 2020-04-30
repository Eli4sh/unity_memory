using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    public static partial class Database
    {
        public static string GetDatabaseString(
            [NotNull] string key)
        {
            return PlayerPrefs.GetString(
                key: key,
                defaultValue: string.Empty);
        }
    }
}