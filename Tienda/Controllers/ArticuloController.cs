using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tienda.Models;
using Tienda.Models.DB;

namespace Tienda.Controllers
{
    [Route("[controller]")]
    public class ArticuloController : Controller
    {

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            List<ArticuloCLS>? listaArticulo = null;
            using (var db = new TiendaContext())
            {
                listaArticulo = (from articulo in db.Articulos
                                    select new ArticuloCLS
                                    {
                                        CodArticulo = articulo.CodArticulo,
                                        NombreArticulo = articulo.NombreArticulo,
                                        Descripcion = articulo.Descripcion,
                                        PrecioUnitario = articulo.PrecioUnitario,
                                        Stock = articulo.Stock,
                                        StockExtra = articulo.StockExtra,
                                        Imagen = articulo.Imagen
                                    }).ToList();
            }
            return View(listaArticulo);
        }

        [HttpGet("[action]")]
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost("[action]")]
        public IActionResult Agregar(ArticuloCLS oArticulo)
        {
            if(!ModelState.IsValid)
            {
                return View(oArticulo);
            }
            using(var db = new TiendaContext())
            {
                Articulo articulo = new Articulo();
                articulo.NombreArticulo = oArticulo.NombreArticulo;
                articulo.Descripcion = oArticulo.Descripcion;
                articulo.PrecioUnitario = oArticulo.PrecioUnitario;
                articulo.Stock = oArticulo.Stock;
                articulo.StockExtra = oArticulo.StockExtra;
                articulo.Imagen = oArticulo.Imagen;
                db.Articulos.Add(articulo);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("[action]")]
        public IActionResult Editar(int id)
        {
            ArticuloCLS oArticulo = new ArticuloCLS();
            using(var db = new TiendaContext())
            {
                Articulo articulo = db.Articulos.Where(p=>p.CodArticulo.Equals(id)).First();
                oArticulo.CodArticulo = articulo.CodArticulo;
                oArticulo.NombreArticulo = articulo.NombreArticulo;
                oArticulo.Descripcion = articulo.Descripcion;
                oArticulo.PrecioUnitario = articulo.PrecioUnitario;
                oArticulo.Stock = articulo.Stock;
                oArticulo.StockExtra = articulo.StockExtra;
            }
            return View(oArticulo);
        }
    }
}