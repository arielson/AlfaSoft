using AlfaSoft.Domain.Models;
using AlfaSoft.Repository.Interfaces;
using AlfaSoft.Service.Interfaces;

namespace AlfaSoft.Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            return _repository.GetByLoginAndPassword(login, password);
        }
    }
}
