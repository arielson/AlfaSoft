using AlfaSoft.Application.Interfaces;
using AlfaSoft.Domain.Models;
using AlfaSoft.Service.Interfaces;
using System.Collections.Generic;

namespace AlfaSoft.Application.Applications
{
    public class ContactApplication : IContactApplication
    {
        private readonly IContactService _service;
        private readonly IUserService _userService;

        public ContactApplication(IContactService service,
            IUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        public void Add(Contact obj)
        {
            if (ValidadeUser(obj.UserActionId))
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
            if (ValidadeUser(obj.UserActionId))
                _service.Remove(obj);
        }

        public void Update(Contact obj)
        {
            if (ValidadeUser(obj.UserActionId))
                _service.Update(obj);
        }

        private bool ValidadeUser(long? id)
        {
            if (!id.HasValue)
                throw new System.Exception("User is not valid");

            var user = _userService.GetById(id.Value);
            if (user == null)
                throw new System.Exception("Operation not permitted");

            return true;
        }
    }
}
