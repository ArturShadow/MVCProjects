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
            List<Empleado>? listEmpleado = null;

            using (var db = new Models.SQLServer.Tid81dContext())
            {
                listEmpleado = (from e in db.Empleados
                                select new Empleado
                                {
                                    IdEmpleado = e.IdEmpleado,
                                    Nombre = e.Nombre,
                                    APaterno = e.APaterno,
                                    AMaterno = e.AMaterno,
                                    Email = e.Email,
                                    Direccion = e.Direccion,
                                    // Sexo = e.Sexo,
                                    Telefono = e.Telefono,
                                    FechaContrato = e.FechaContrato,
                                    Sueldo = e.Sueldo
                                }).ToList();
            }
            return View(listEmpleado);
        }
    }
}