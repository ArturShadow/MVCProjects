using System;
using System.Collections.Generic;

namespace Tienda.Models.DB;

public partial class Compra
{
    public int NoCompra { get; set; }

    public int? Cliente { get; set; }

    public int? Articulo { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? Unidades { get; set; }

    public decimal? Total { get; set; }

    public virtual Articulo? ArticuloNavigation { get; set; }

    public virtual Cliente? ClienteNavigation { get; set; }
}
