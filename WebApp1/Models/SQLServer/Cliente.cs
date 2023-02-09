using System;
using System.Collections.Generic;

namespace WebApp1.Models.SQLServer;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? APaterno { get; set; }

    public string? AMaterno { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public int? Sexo { get; set; }

    public string? Telefono { get; set; }

    public virtual Sexo? SexoNavigation { get; set; }
}
