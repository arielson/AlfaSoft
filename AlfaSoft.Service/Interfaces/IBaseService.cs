using System.Collections.Generic;
using System.Linq;

namespace AlfaSoft.Service.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void AddRange(List<TEntity> obj);

        TEntity GetById(long id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
