using System;
using JetBrains.Annotations;

namespace Core
{
    public static partial class Database
    {
        public static DateTime? GetDatabaseDateTime(
            [NotNull] string key)
        {
            long? longValue = GetDatabaseLong(key: key);

            if (!longValue.HasValue) return null;

            return new DateTime(ticks: longValue.Value);
        }
    }
}