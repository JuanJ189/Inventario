using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventarioSuperModelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre de la categoría")]
        [Display(Name = "Nombre de la categoría: ")]
        public string? Nombre { get; set; }

        [Display(Name = "Orden de visualización: ")]
        public int? Orden { get; set; }
    }
}
