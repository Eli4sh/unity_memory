using JetBrains.Annotations;

namespace Core
{
    public static partial class Database
    {
        public static void SetDatabaseLong(
            [NotNull] string key,
            long value)
        {
            SetDatabaseString(
                key: key,
                value: value.ToString());
        }
    }
}