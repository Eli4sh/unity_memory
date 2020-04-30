using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    public static partial class Database
    {
        public static void SetDatabaseInt(
            [NotNull] string key,
            int value)
        {
            PlayerPrefs.SetInt(
                key: key,
                value: value);
        }
    }
}