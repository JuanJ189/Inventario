using InventarioSuperDatos.Data.Repositorio.IRepositorio;
using InventarioSuperDatos.Data;
using InventarioSuperModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioSuper.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedor;

        public CategoriasController(IContenedorTrabajo contenedor)
        {
            _contenedor = contenedor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedor.Categoria.Add(categoria);
                await _contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var categoria = await _contenedor.Categoria.Get(id);

            if (categoria is null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedor.Categoria.update(categoria);
                await _contenedor.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }

        #region Apis
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {Data = _contenedor.Categoria.GetAll() });
        }
        #endregion
    }
}
