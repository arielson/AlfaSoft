using AlfaSoft.Domain.Models;
using AlfaSoft.Repository.Interfaces;

namespace AlfaSoft.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly SqlContext _context;
        public UserRepository(SqlContext context) : base(context)
        {
            _context = context;
        }
    }
}
