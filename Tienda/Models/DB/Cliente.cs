using System;
using System.Collections.Generic;

namespace Tienda.Models.DB;

public partial class Cliente
{
    public int CodCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Empresa { get; set; }

    public string? Puesto { get; set; }

    public string? Cp { get; set; }

    public string? Provincia { get; set; }

    public string? Telefono { get; set; }

    public DateOnly? FehaNacimiento { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Compra> Compras { get; } = new List<Compra>();
}
