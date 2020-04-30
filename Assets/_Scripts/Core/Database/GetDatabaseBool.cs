using JetBrains.Annotations;

namespace Core
{
    public static partial class Database
    {
        public static bool? GetDatabaseBool(
            [NotNull] string key)
        {
            int? intValue = GetDatabaseInt(key: key);

            if (!intValue.HasValue)
            {
                return null;
            }

            return intValue.Value == 1;
        }
    }
}