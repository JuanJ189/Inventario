using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventarioSuperDatos.Data.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task<T?> Get(int? id);

        Task<IEnumerable<T>> GetAll(
            Expression<Func< T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null,
            CancellationToken cancellationToken = default
        );

        Task<T?> GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null,
            CancellationToken cancellationToken = default
        );

        Task Add(T entity, CancellationToken cancellationToken = default);

        Task Remove(int id, CancellationToken cancellationToken = default);

        Task Remove(T entity, CancellationToken cancellationToken = default);

        
    }
}
