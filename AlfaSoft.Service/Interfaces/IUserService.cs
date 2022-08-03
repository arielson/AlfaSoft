using AlfaSoft.Domain.Models;

namespace AlfaSoft.Service.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User GetByLoginAndPassword(string login, string password);
    }
}
