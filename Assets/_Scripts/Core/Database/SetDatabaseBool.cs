using JetBrains.Annotations;

namespace Core
{
    public static partial class Database
    {
        public static void SetDatabaseBool(
            [NotNull] string key,
            bool value)
        {
            SetDatabaseInt(
                key: key,
                value: value ? 1 : 0);
        }
    }
}