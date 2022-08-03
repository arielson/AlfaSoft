using AlfaSoft.Application.Interfaces;
using AlfaSoft.Domain.Models;
using AlfaSoft.Service.Interfaces;
using System.Collections.Generic;

namespace AlfaSoft.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _service;

        public UserApplication(IUserService service)
        {
            _service = service;
        }

        public void Add(User obj)
        {
            _service.Add(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<User> GetAll()
        {
            return _service.GetAll();
        }

        public User GetById(long id)
        {
            return _service.GetById(id);
        }

        public void Remove(User obj)
        {
            _service.Remove(obj);
        }

        public void Update(User obj)
        {
            _service.Update(obj);
        }
    }
}
