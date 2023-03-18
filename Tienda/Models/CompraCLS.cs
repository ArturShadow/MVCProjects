using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Models
{
    
    public class CompraCLS
    {
        public int Cliente { get; set; }

    public int Articulo { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? Unidades { get; set; }

    public decimal? Total { get; set; }
    }
}