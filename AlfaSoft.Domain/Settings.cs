using AlfaSoft.Domain.Enumerators;

namespace AlfaSoft.Domain
{
    public class Settings
    {
        public static string ConnectionString { get; set; }
        public static ConnectionType Type { get; set; } = ConnectionType.MySql;
    }
}
