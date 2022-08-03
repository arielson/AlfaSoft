using AlfaSoft.Application.Interfaces;
using AlfaSoft.Domain.Models;
using AlfaSoft.Service.Interfaces;
using System.Collections.Generic;

namespace AlfaSoft.Application.Applications
{
    public class ContactApplication : IContactApplication
    {
        private readonly IContactService _service;

        public ContactApplication(IContactService service)
        {
            _service = service;
        }

        public void Add(Contact obj)
        {
            _service.Add(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<Contact> GetAll()
        {
            return _service.GetAll();
        }

        public Contact GetById(long id)
        {
            return _service.GetById(id);
        }

        public void Remove(Contact obj)
        {
            _service.Remove(obj);
        }

        public void Update(Contact obj)
        {
            _service.Update(obj);
        }
    }
}
