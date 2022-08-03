using AlfaSoft.Domain.Models;
using System.Collections.Generic;

namespace AlfaSoft.Application.Interfaces
{
    public interface IContactApplication
    {
        void Add(Contact obj);

        Contact GetById(long id);

        IEnumerable<Contact> GetAll();

        void Update(Contact obj);

        void Remove(Contact obj);

        void Dispose();
    }
}
