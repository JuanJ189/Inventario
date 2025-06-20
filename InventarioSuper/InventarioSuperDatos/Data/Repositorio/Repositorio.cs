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

        public async Task Add(T entity, CancellationToken cancellationToken = default)
        {
            await dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task<T?> Get(int? id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null,Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,string? includeProperties = null,CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(
                    new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(
                    new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task Remove(int id, CancellationToken cancellationToken = default)
        {
            var entity = await dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public async Task Remove(T entity, CancellationToken cancellationToken = default)
        {
            dbSet.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
