using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventarioSuperDatos.Data.Repositorio.IRepositorio;
using System.Threading.Tasks;

namespace InventarioSuper.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductosController : Controller
    {
        private readonly IContenedorTrabajo _contenedortrabajo;

        public ProductosController(IContenedorTrabajo trabajo)
        {
            _contenedortrabajo = trabajo;
        }

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region Llamadas a la Api
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _contenedortrabajo.Producto.GetAll(includeProperties: "Categoria");
            return Json(new { data = productos });
        }
        #endregion
    }
}
