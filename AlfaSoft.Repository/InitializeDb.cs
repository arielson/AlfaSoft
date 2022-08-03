using AlfaSoft.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AlfaSoft.Repository
{
    public class InitializeDb
    {
        public static void Initialize(SqlContext context)
        {
            context.Database.EnsureCreated();

            try
            {
                if (!context.User.IgnoreQueryFilters().Any())
                {
                    User user = new()
                    {
                        Login = "alfasoft",
                        Name = "AlfaSoft",
                        Password = "password"
                    };

                    context.User.Add(user);
                }
            }
            catch (Exception)
            {
                context.Database.RollbackTransaction();
                throw;
            }
        }
    }
}
