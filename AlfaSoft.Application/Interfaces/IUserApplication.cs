using AlfaSoft.Domain.Models;
using System.Collections.Generic;

namespace AlfaSoft.Application.Interfaces
{
    public interface IUserApplication
    {
        void Add(User obj);

        User GetById(long id);

        User GetByLoginAndPassword(string login, string password);

        IEnumerable<User> GetAll();

        void Update(User obj);

        void Remove(User obj);

        void Dispose();
    }
}
