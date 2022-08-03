using AlfaSoft.Domain.Enumerators;

namespace AlfaSoft.Domain
{
    public class Settings
    {
        public static string ConnectionString { get; set; } = "Server=localhost;Database=AlfaSoft;Port=5432;User Id=postgres;Password=Httpr0x1!;";
        public static ConnectionType Type { get; set; } = ConnectionType.MySql;
    }
}
