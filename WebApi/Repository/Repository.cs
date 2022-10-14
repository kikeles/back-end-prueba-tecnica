using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly JugueteContext _context;
        private readonly DbSet<TEntity> _dbset;

        public Repository(JugueteContext context)
        {
            this._context = context;
            this._dbset = context.Set<TEntity>();
        }

        //Obtener todos los elementos de la tabla
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbset.ToListAsync();

        //Obtener un solo elemento de la tabla
        public async Task<TEntity> GetElementAsync(int id) => await _dbset.FindAsync(id);

        //Agregar y despues usar el método Save()
        public void Add(TEntity data)
        {
            _dbset.Add(data);
        }

        //Actualizar y despues usar el método Save()
        public void Update(TEntity data)
        {
            //sobrescribe el elemento enviado
            _dbset.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }

        //Eliminar y despues usar el método Save()
        public void Delete(TEntity data)
        {
            _dbset.Remove(data);
        }

        //se usa despues del Agregar, Actualizar o Eliminar
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
