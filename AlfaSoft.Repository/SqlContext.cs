using AlfaSoft.Domain;
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
                options.UseSqlServer(Settings.ConnectionString);
            }
        }

        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}
