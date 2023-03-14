using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            List<EmpleadoCLS>? listEmpleado = null;

            using (var db = new Models.DB.Tid81dContext())
            {
                listEmpleado = (from empleado in db.Empleados
                                join sexo in db.Sexos on empleado.Sexo equals sexo.IdSexo
                                join tipoUsuario in db.TipoUsuarios on empleado.TipoUsuario equals tipoUsuario.IdTipoUsuario
                                join tipoContrato in db.TipoContratos on empleado.TipoContrato equals tipoContrato.IdTipoContrato
                                select new EmpleadoCLS
                                {
                                    IdEmpleado = empleado.IdEmpleado,
                                    Nombre = empleado.Nombre,
                                    APaterno = empleado.APaterno,
                                    AMaterno = empleado.AMaterno,
                                    Email = empleado.Email,
                                    Direccion = empleado.Direccion,
                                    // Sexo = empleado.Sexo,
                                    NombreSexo = sexo.Descripcion,
                                    Telefono = empleado.Telefono,
                                    FechaContrato = empleado.FechaContrato,
                                    Sueldo = empleado.Sueldo,
                                    NombreTipoUsuario = tipoUsuario.Descripcion,
                                    NombreTipoContrato = tipoContrato.Descripcion
                                }).ToList();
            }
            return View(listEmpleado);
        }
    }
}