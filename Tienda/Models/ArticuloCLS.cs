using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Models
{
    public class ArticuloCLS
    {
        [Display(Name = "Codigo del articulo")]
        public int CodArticulo { get; set; }

        [Display(Name = "Articulo")]
        [StringLength(100,ErrorMessage ="Solo se permiten 100 caracteres")]
        [Required]
        public string? NombreArticulo { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(250,ErrorMessage ="Solo se permiten 250 caracteres")]
        [Required]
        public string? Descripcion { get; set; }

        [Display(Name = "Precio por unidad")]
        [Required]
        public decimal? PrecioUnitario { get; set; }

        [Display(Name = "Existencia")]
        [Required]
        public int? Stock { get; set; }

        [Display(Name = "Existencia de seguridad")]
        [Required]
        public int? StockExtra { get; set; }
    }
}