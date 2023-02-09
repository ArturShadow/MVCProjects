using System;
using System.Collections.Generic;

namespace WebApp1.Models.DB;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? APaterno { get; set; }

    public string? AMaterno { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public int? Sexo { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaContrato { get; set; }

    public decimal? Sueldo { get; set; }

    public virtual Sexo? SexoNavigation { get; set; }
}
