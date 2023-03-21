using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Tienda.Models;
using Tienda.Models.DB;

namespace Tienda.Controllers
{
    [Route("[controller]")]
    public class CompraController : Controller
    {
        private List<SelectListItem>? listaArticulo = null;
        private List<SelectListItem>? listaCliente = null;
        private List<CompraCLS>? listaCompra = null;

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            using (var db = new TiendaContext())
            {
                listaCompra = (from compra in db.Compras
                join articulo in db.Articulos on compra.Articulo equals articulo.CodArticulo
                join cliente in db.Clientes on compra.Cliente equals cliente.CodCliente
                select new CompraCLS{
                    NombreArticulo = articulo.NombreArticulo,
                    NombreCliente = cliente.Nombre,
                    Fecha = compra.Fecha,
                    Unidades = compra.Unidades,
                    Total = compra.Total
                }).ToList();
            }
            return View(listaCompra);
        }

        private void Articulo(){
            using (var db = new TiendaContext())
            {
                listaArticulo = (from articulo in db.Articulos select new SelectListItem(){
                    Value = articulo.CodArticulo.ToString(),
                    Text = articulo.NombreArticulo
                }).ToList<SelectListItem>();
            }
            listaArticulo.Insert(0, new SelectListItem { Value = "", Text = "--Selecciona--"});
        }

        private void Cliente(){
            using(var db = new TiendaContext())
            {
                listaCliente = (from cliente in db.Clientes select new SelectListItem()
                {
                    Value = cliente.CodCliente.ToString(),
                    Text = cliente.Nombre
                }).ToList<SelectListItem>();
            }
            listaCliente.Insert(0, new SelectListItem { Value = "", Text = "--Selecciona--"});
        }
        public void LlenarCombos()
        {
            Articulo();
            Cliente();
            ViewBag.listaArticulo = listaArticulo;
            ViewBag.listaCliente = listaCliente;
        }

        [HttpGet("[action]")]
        public IActionResult Agregar()
        {
            LlenarCombos();
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Agregar(CompraCLS oCompra)
        {
            if(!ModelState.IsValid){
                LlenarCombos();
                return View(oCompra);
            }

            using (var db = new TiendaContext())
            {
                var compra = new Compra();
                Articulo precioArticulo = (Articulo)db.Articulos.Where(p=>p.CodArticulo.Equals(oCompra.Articulo));
                compra.Cliente = oCompra.Cliente;
                compra.Articulo = oCompra.Articulo;
                compra.Fecha = oCompra.Fecha;
                compra.Unidades = oCompra.Unidades;
                compra.Total = (precioArticulo.PrecioUnitario * oCompra.Unidades);
                db.Compras.Add(compra);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}