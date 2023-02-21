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
            //Creamos una lista para guardar la consulta para mostrar en la vista despues
            List<ClienteCLS>? listaCliente = null;
            using (var bd = new Models.SQLServer.Tid81dContext())
            // using (var bd = new Models.SQLServer.Tid81dContext()) //Creamos una instancia del contexto de la base de datos
            {

                listaCliente = (from c in bd.Clientes
                select new ClienteCLS // Se crea un nuevo objeto de la Clase ClientesCLS para cada resultado de la resultado despues lo guarda en la lista
                {
                    IdCliente=c.IdCliente, //Cada campo del resultado se guarda en su respectivo campo del objeto
                    Nombre = c.Nombre,
                    APaterno = c.APaterno,
                    AMaterno = c.AMaterno,
                    Email = c.Email,
                    Direccion = c.Direccion,
                    // Sexo = c.Sexo,
                    Telefono = c.Telefono
                }).ToList();
            }
            // Se mandas la lista a la vistaz
            return View(listaCliente);
        }


    }
}