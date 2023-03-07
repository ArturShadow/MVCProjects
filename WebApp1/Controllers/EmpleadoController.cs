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
            List<EmpleadoCLS>? listaEmpleado = null;
            using (var db = new Models.DB.Tid81dContext())
            {
                listaEmpleado = (from empleado in db.Empleados
                                join Sexo in db.Sexos on empleado.Sexo equals Sexo.IdSexo
                                join TipoContrato in db.TipoContratos on empleado.TipoContrato equals TipoContrato.IdTipoContrato
                                join TipoUsuario in db.TipoUsuarios on empleado.TipoUsuario equals TipoUsuario.IdTipoUsuario
                                select new EmpleadoCLS
                                {
                                    IdEmpleado = empleado.IdEmpleado,
                                    Nombre = empleado.Nombre,
                                    APaterno = empleado.APaterno,
                                    AMaterno = empleado.AMaterno,
                                    Email = empleado.Email,
                                    Direccion = empleado.Direccion,
                                    NombreSexo = Sexo.Descripcion,
                                    //Sexo=empleado.Sexo,
                                    Telefono = empleado.Telefono,
                                    FechaContrato = (DateOnly?)empleado.FechaContrato,
                                    Sueldo = (decimal?)empleado.Sueldo,
                                    NombreTipoContrato = TipoContrato.Descripcion,
                                    //TipoContrato = (int?)empleado.TipoContrato,
                                    NombreTipoUsuario = TipoUsuario.Descripcion
                                    //TipoUsuario = (int?)empleado.TipoUsuario
                                }).ToList();
            }
            return View(listaEmpleado);
        }
    }
}