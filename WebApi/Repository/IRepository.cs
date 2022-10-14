using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetElementAsync(int id);

        void Add(TEntity data);

        void Update(TEntity data);

        void Delete(TEntity data);

        void Save();
    }
}
