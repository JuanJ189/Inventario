using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventarioSuperModelos;

namespace InventarioSuperDatos.Data.Repositorio.IRepositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        public void update(Producto producto);

        
    }
}
