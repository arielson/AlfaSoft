using AlfaSoft.Domain.Models;
using AlfaSoft.Repository.Interfaces;

namespace AlfaSoft.Repository.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly SqlContext _context;
        public ContactRepository(SqlContext context) : base(context)
        {
            _context = context;
        }
    }
}
