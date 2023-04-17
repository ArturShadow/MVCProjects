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
                listaCliente = (from cliente in db.Clientes
                                where cliente.Estado.Equals(1)
                                select new ClienteCLS()
                                {
                                    CodCliente = cliente.CodCliente,
                                    Nombre = cliente.Nombre,
                                    Apellidos = cliente.Apellidos,
                                    Empresa = cliente.Empresa,
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
            if (!ModelState.IsValid)
            {
                return View(oClliente);
            }
            using (var db = new TiendaContext())
            {
                Cliente cliente = new Cliente();
                cliente.Nombre = oClliente.Nombre;
                cliente.Apellidos = oClliente.Apellidos;
                cliente.Empresa = oClliente.Empresa;
                cliente.Puesto = oClliente.Puesto;
                cliente.Cp = oClliente.Cp;
                cliente.Provincia = oClliente.Provincia;
                cliente.Telefono = oClliente.Telefono;
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet("[action]")]
        public IActionResult Editar(int id)
        {
            ClienteCLS oCliente = new ClienteCLS();
            using (var db = new TiendaContext())
            {
                Cliente cliente = db.Clientes.Where(p => p.CodCliente.Equals(id)).First();
                oCliente.CodCliente = cliente.CodCliente;
                oCliente.Nombre = cliente.Nombre;
                oCliente.Apellidos = cliente.Apellidos;
                oCliente.Empresa = cliente.Empresa;
                oCliente.Puesto = cliente.Puesto;
                oCliente.Cp = cliente.Cp;
                oCliente.Provincia = cliente.Provincia;
                oCliente.Telefono = cliente.Telefono;
            }
            return View(oCliente);
        }

        [HttpPost("[action]")]
        public IActionResult Editar(ClienteCLS oCliente){
            if(!ModelState.IsValid){
                return View(oCliente);
            }
            int codCliente = oCliente.CodCliente;
            using(var db = new TiendaContext())
            {
                Cliente cliente = db.Clientes.Where(p => p.CodCliente.Equals(codCliente)).First();
                cliente.CodCliente = oCliente.CodCliente;
                cliente.Nombre = oCliente.Nombre;
                cliente.Apellidos = oCliente.Apellidos;
                cliente.Empresa = oCliente.Empresa;
                cliente.Puesto = oCliente.Puesto;
                cliente.Cp = oCliente.Cp;
                cliente.Provincia = oCliente.Provincia;
                cliente.Telefono = oCliente.Telefono;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("[action]")]
        public IActionResult Eliminar(int id)
        {
            using (var db = new TiendaContext())
            {
                var cliente = db.Clientes.Where(c => c.CodCliente.Equals(id)).First();
                cliente.Estado = 0;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}