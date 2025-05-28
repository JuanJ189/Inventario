using InventarioSuperDatos.Data.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventarioSuperDatos.Data.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly DbContext Datos;
        internal DbSet<T> dbSet;

        public Repositorio(DbContext Datos)
        {
            this.Datos = Datos;
            this.dbSet = Datos.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task<T?> Get(int? id)
        {
            var T = await dbSet.FindAsync(id);

            return T;
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> Consulta = dbSet;

            if(filter != null)
            {
                Consulta = Consulta.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Consulta = Consulta.Include(item);
                }
            }

            if (orderBy != null)
            {
                return orderBy(Consulta).ToList();
            }

            return Consulta.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> Consulta = dbSet;

            if(filter != null)
            {
                Consulta = Consulta.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    Consulta = Consulta.Include(item);
                }
            }

            return Consulta.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
