using InventarioSuperDatos.Data.Repositorio.IRepositorio;
using InventarioSuperModelos;
using InventarioSuper.Data;

namespace InventarioSuperDatos.Data.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext Db;
        public ProductoRepositorio(ApplicationDbContext Datos) : base(Datos)
        {
            Db = Datos;
        }

        public void update(Producto producto)
        {
            var objdb = Db.Productos.FirstOrDefault(s => s.Id == producto.Id);
            if (objdb == null)
            {
                throw new ArgumentNullException(nameof(objdb), "Categoria no encontrada en la base de datos.");
            }
            objdb.Nombre = producto.Nombre;
            objdb.Descripcion = producto.Descripcion;
            objdb.PrecioCompra = producto.PrecioCompra;
            objdb.Precio = producto.Precio;
            objdb.Cantidad = producto.Cantidad;
            objdb.CategoriaId = producto.CategoriaId;
            objdb.FechaCreacion = producto.FechaCreacion;
            objdb.url = producto.url;
        }
    }
}
