using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Models
{
    
    public class CompraCLS
    {
        [Display(Name = "Numero de compra")]
        public int NoCompra { get; set; }
        [Required]
        public int Cliente { get; set; }

        [Required]
        public int Articulo { get; set; }

        public DateOnly? Fecha { get; set; }

        [Required]
        public int? Unidades { get; set; }

        public decimal? Total { get; set; }

        public String? NombreArticulo { get; set; }

        public String? NombreCliente { get; set; }
    }
}

