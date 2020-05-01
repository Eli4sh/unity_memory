using JetBrains.Annotations;

namespace Core
{
    public static partial class Database
    {
        public static long? GetDatabaseLong(
            [NotNull] string key)
        {
            string strValue = GetDatabaseString(key: key);

            if (strValue == null) return null;

            long value;

            if (long.TryParse(
                s: strValue,
                result: out value))
                return value;

            return null;
        }
    }
}