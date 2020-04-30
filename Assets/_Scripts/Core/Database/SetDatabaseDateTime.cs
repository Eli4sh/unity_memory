using System;
using JetBrains.Annotations;

namespace Core
{
    public static partial class Database
    {
        public static void SetDatabaseDateTime(
            [NotNull] string key,
            DateTime value)
        {
            SetDatabaseLong(
                key: key,
                value: value.Ticks);
        }
    }
}