using AlfaSoft.Domain.Models;

namespace AlfaSoft.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByLoginAndPassword(string login, string password);
    }
}
