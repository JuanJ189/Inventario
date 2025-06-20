using InventarioSuper.Data;
using InventarioSuperDatos.Data.Repositorio.IRepositorio;
using System.Threading.Tasks;

namespace InventarioSuperDatos.Data.Repositorio
{
    public class ContenedorTrabjo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabjo(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepositorio(_db);
            Producto = new ProductoRepositorio(_db);
        }

        public ICategoriaRepositorio Categoria { get; private set; }
        public IProductoRepositorio Producto { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
