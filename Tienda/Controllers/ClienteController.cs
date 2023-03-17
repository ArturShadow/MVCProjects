using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tienda.Models;
using Tienda.Models.DB;

namespace Tienda.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private List<ClienteCLS>? listaCliente = null;
        public IActionResult Index()
        {
            using (var db = new TiendaContext())
            {
                listaCliente = (from cliente in db.Clientes select new ClienteCLS(){
                    CodCliente =cliente.CodCliente,
                    Nombre = cliente.Nombre,
                    Apellidos = cliente.Apellidos,
                    Empresa = cliente.Empresa,
                    FehaNacimiento=cliente.FehaNacimiento,
                    Provincia = cliente.Provincia,
                    Puesto = cliente.Puesto,
                    Cp = cliente.Cp,
                    Telefono = cliente.Telefono
                }).ToList();
            }
            return View(listaCliente);
        }

        [HttpGet("[action]")]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Agregar(ClienteCLS oClliente)
        {
            if(!ModelState.IsValid){
                return View(oClliente);
            }
            using(var db = new TiendaContext()){
                Cliente cliente = new Cliente();
                cliente.Nombre = oClliente.Nombre;
                cliente.Apellidos = oClliente.Apellidos;
                cliente.Empresa = oClliente.Empresa;
                cliente.Puesto = oClliente.Puesto;
                cliente.Cp = oClliente.Cp;
                cliente.Provincia = oClliente.Provincia;
                cliente.Telefono = oClliente.Telefono;
                cliente.FehaNacimiento = oClliente.FehaNacimiento;
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}