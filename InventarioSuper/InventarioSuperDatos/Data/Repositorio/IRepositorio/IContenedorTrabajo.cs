using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioSuperDatos.Data.Repositorio.IRepositorio
{
    public interface IContenedorTrabajo : IDisposable
    {
        ICategoriaRepositorio Categoria { get; }
        IProductoRepositorio Producto { get; }
        Task Save();
    }
}
