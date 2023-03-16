using System;
using System.Collections.Generic;

namespace Tienda.Models.DB;

public partial class Articulo
{
    public int CodArticulo { get; set; }

    public string? NombreArticulo { get; set; }

    public string? Descripcion { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? Stock { get; set; }

    public int? StockExtra { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<Compra> Compras { get; } = new List<Compra>();
}
