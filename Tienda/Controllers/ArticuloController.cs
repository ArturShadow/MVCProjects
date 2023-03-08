using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tienda.Models;

namespace Tienda.Controllers
{
    [Route("[controller]")]
    public class ArticuloController : Controller
    {

        public IActionResult Index()
        {
            List<ArticuloCLS>? listaArticulo = null;
            using(var db = new Models.DB.TiendaContext()){
                listaArticulo = (from articulo in db.Articulos select new ArticuloCLS{
                    CodArticulo = articulo.CodArticulo,
                    NombreArticulo = articulo.NombreArticulo,
                    Descripcion = articulo.Descripcion,
                    PrecioUnitario = articulo.PrecioUnitario,
                    Stock = articulo.Stock,
                    StockExtra = articulo.StockExtra
                }).ToList();
            }
            return View(listaArticulo);
        }
    }
}