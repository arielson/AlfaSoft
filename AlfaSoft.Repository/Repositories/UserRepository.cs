using AlfaSoft.Domain.Models;
using AlfaSoft.Repository.Interfaces;
using System.Linq;

namespace AlfaSoft.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SqlContext _context;
        public UserRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            return _context.Set<User>().SingleOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Password == password);
        }
    }
}
