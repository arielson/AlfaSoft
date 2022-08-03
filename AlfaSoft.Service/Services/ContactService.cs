using AlfaSoft.Domain.Models;
using AlfaSoft.Repository.Interfaces;
using AlfaSoft.Service.Interfaces;

namespace AlfaSoft.Service.Services
{
    public class ContactService : BaseService<Contact>, IContactService
    {
        public readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
