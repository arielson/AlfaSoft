using AlfaSoft.Domain;
using AlfaSoft.Domain.Enumerators;
using AlfaSoft.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AlfaSoft.Repository
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                switch (Settings.Type)
                {
                    case ConnectionType.MySql:
                        options.UseMySql(Settings.ConnectionString, ServerVersion.AutoDetect(Settings.ConnectionString));
                        break;
                    case ConnectionType.SqlServer:
                        options.UseSqlServer(Settings.ConnectionString);
                        break;
                    case ConnectionType.PostgreSql:
                        options.UseNpgsql(Settings.ConnectionString);
                        break;
                    default:
                        options.UseNpgsql(Settings.ConnectionString);
                        break;
                }
            }
        }

        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}
