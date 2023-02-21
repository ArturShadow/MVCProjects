using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            List<ProductoCLS> listaProducto = new List<ProductoCLS>();
            using (var db = new Models.SQLServer.Tid81dContext())
            {
                listaProducto = (from producto in db.Productos
                                 select new ProductoCLS
                                 {
                                     IdProducto = producto.IdProducto,
                                     Descripcion = producto.Descripcion,
                                     Precio = producto.Precio,
                                     Inventario = producto.Inventario,
                                 }).ToList();
            };
            return View(listaProducto);
        }
    }
}