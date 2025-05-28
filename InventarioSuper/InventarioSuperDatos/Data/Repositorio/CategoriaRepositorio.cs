using InventarioSuperDatos.Data.Repositorio.IRepositorio;
using InventarioSuperModelos;
using InventarioSuper.Data;

namespace InventarioSuperDatos.Data.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext Db;
        public CategoriaRepositorio(ApplicationDbContext Datos) : base(Datos)
        {
            Db = Datos;
        }
        public void update(Categoria categoria)
        {
            var objdb = Db.Categorias.FirstOrDefault(s => s.Id == categoria.Id );
            if (objdb == null)
            {
                throw new ArgumentNullException(nameof(objdb), "Categoria no encontrada en la base de datos.");
            }
            objdb.Nombre = categoria.Nombre;
            objdb.Orden = categoria.Orden;
        }
    }
}
