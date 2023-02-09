using System;
using System.Collections.Generic;

namespace WebApp1.Models.SQLServer;

public partial class Sexo
{
    public int IdSexo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
