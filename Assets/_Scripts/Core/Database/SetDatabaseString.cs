using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    public static partial class Database
    {
        public static void SetDatabaseString(
            [NotNull] string key,
            string value)
        {
            PlayerPrefs.SetString(
                key: key,
                value: value);
        }
    }
}