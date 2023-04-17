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
        // Se obntiene la informacion del entorno una aplicacion en ejecucion
        private readonly IWebHostEnvironment _env;
        public ArticuloController(IWebHostEnvironment env)
        {
            _env = env;
        }
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            List<ArticuloCLS>? listaArticulo = null;
            using (var db = new TiendaContext())
            {
                listaArticulo = (from articulo in db.Articulos
                                where articulo.Estado.Equals(1)
                                select new ArticuloCLS
                                {
                                    CodArticulo = articulo.CodArticulo,
                                    NombreArticulo = articulo.NombreArticulo,
                                    Descripcion = articulo.Descripcion,
                                    PrecioUnitario = articulo.PrecioUnitario,
                                    Stock = articulo.Stock,
                                    StockExtra = articulo.StockExtra,
                                    NombreImagen = articulo.Imagen
                                }).ToList();
            }
            return View(listaArticulo);
        }
        private void GuardarArchivo(IFormFile file)
        {
            // Guardo el nombre de la imagen
            string fileName = file.FileName;
            // De _env.WebRotPath se obtiene la ruta de la y poder guardar las imagenes dentro del directortoio raiz expuesto
            var path = Path.Combine(_env.WebRootPath, "images\\", fileName);
            //Reemplazo las '\' de la ruta por '/'
            var filePath = path.Replace("\\", "/");
            using (var archivoStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(archivoStream);
            }
        }
        [HttpGet("[action]")]
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost("[action]")]
        public IActionResult Agregar(ArticuloCLS oArticulo)
        {
            if (!ModelState.IsValid) return View(oArticulo);
            // Si el archivo recibido es nulo, se guardara como nombre de la imagen 'no-image-found.png'
            oArticulo.NombreImagen = oArticulo.Imagen == null ? "no-image-found.png" : oArticulo.Imagen.FileName;
            if (oArticulo.Imagen != null){
                GuardarArchivo(oArticulo.Imagen);
            }
            using (var db = new TiendaContext())
            {
                Articulo articulo = new Articulo();
                articulo.NombreArticulo = oArticulo.NombreArticulo;
                articulo.Descripcion = oArticulo.Descripcion;
                articulo.PrecioUnitario = oArticulo.PrecioUnitario;
                articulo.Stock = oArticulo.Stock;
                articulo.StockExtra = oArticulo.StockExtra;
                articulo.Imagen = oArticulo.NombreImagen;
                db.Articulos.Add(articulo);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet("[action]")]
        public IActionResult Editar(int id)
        {
            ArticuloCLS oArticulo = new ArticuloCLS();
            using (var db = new TiendaContext())
            {
                Articulo articulo = db.Articulos.Where(p => p.CodArticulo.Equals(id)).First();
                oArticulo.CodArticulo = articulo.CodArticulo;
                oArticulo.NombreArticulo = articulo.NombreArticulo;
                oArticulo.Descripcion = articulo.Descripcion;
                oArticulo.PrecioUnitario = articulo.PrecioUnitario;
                oArticulo.Stock = articulo.Stock;
                oArticulo.StockExtra = articulo.StockExtra;
                oArticulo.NombreImagen = articulo.Imagen;
            }
            return View(oArticulo);
        }
        [HttpPost("[action]")]
        public IActionResult Editar(ArticuloCLS oArticulo)
        {
            if(!ModelState.IsValid) return View(oArticulo);
            using (var db = new TiendaContext())
            {
                var articulo = db.Articulos.Where(a => a.CodArticulo.Equals(oArticulo.CodArticulo)).First();
                articulo.NombreArticulo = oArticulo.NombreArticulo;
                articulo.Descripcion = oArticulo.Descripcion;
                articulo.PrecioUnitario = oArticulo.PrecioUnitario;
                articulo.Stock = oArticulo.Stock;
                articulo.StockExtra = oArticulo.StockExtra;
                // si no se recibio una nueva imagen, se guardara la misma imagen
                if(oArticulo.Imagen == null)
                {
                    articulo.Imagen = articulo.Imagen;
                }
                // Sino se comprueba que el nombre de la imagen sea diferente para guardarla
                else if (oArticulo.Imagen.FileName != articulo.Imagen)
                {
                    GuardarArchivo(oArticulo.Imagen);
                    articulo.Imagen = oArticulo.Imagen.FileName;
                }
                
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("[action]")]
        public IActionResult Eliminar(int id)
        {
            using (var db = new TiendaContext()){
                var articulo = db.Articulos.Where(a=>a.CodArticulo.Equals(id)).First();
                articulo.Estado = 0;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}