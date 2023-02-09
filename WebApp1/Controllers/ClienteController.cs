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
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            List<ClienteCLS> listaCliente = new List<ClienteCLS>();
            //using (var bd = new Models.DB.Tid81dContext())
            using (var bd = new Models.SQLServer.Tid81dContext())
            {

                listaCliente = (from c in bd.Clientes
                select new ClienteCLS
                {
                    IdCliente=c.IdCliente,
                    Nombre=c.Nombre,
                    APaterno=c.APaterno,
                    AMaterno=c.AMaterno,
                    Email=c.Email,
                    Direccion=c.Direccion,
                    // Sexo=c.Sexo,
                    Telefono=c.Telefono
                }).ToList();
            }
            return View(listaCliente);
        }


    }
}