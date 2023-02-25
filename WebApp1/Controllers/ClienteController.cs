using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using WebApp1.Models.DB;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace WebApp1.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {

        public IActionResult Index()
        {
            List<ClienteCLS> listaCliente;

            using (var db = new Tid81dContext())
            {
                listaCliente = (from cliente in db.Clientes
                                select new ClienteCLS
                                {
                                    IdCliente = cliente.IdCliente,
                                    Nombre = cliente.Nombre,
                                    APaterno = cliente.APaterno,
                                    AMaterno = cliente.AMaterno,
                                    Email = cliente.Email,
                                    Direccion = cliente.Direccion,
                                    Sexo = (int?)cliente.Sexo,
                                    Telefono = cliente.Telefono
                                }).ToList();
            }
            return View(listaCliente);
        }
        //Llenar el combobox de Sexo
        List<SelectListItem> listaSexo;
        private void LlenarSexo()
        {
            using (var db = new Tid81dContext())
            {
                listaSexo = (from sexo in db.Sexos
                            select new SelectListItem
                            {
                                Text = sexo.Descripcion,
                                Value = sexo.IdSexo.ToString()
                            }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "-- Selecciona --", Value = "" });
            }
        }

        public ActionResult Agregar()
        {
            // Llamamos al metodo LlenarSexo
            LlenarSexo();
            // Le pasamos la lista de sexos a la vista
            ViewBag.lista = listaSexo;

            return View();
        }

        [Route("Cliente/Agregar")]
        [HttpPost("{oCliente}")]
        public ActionResult Agregar(ClienteCLS oCliente)
        {
            if (!ModelState.IsValid)
            {
                LlenarSexo();
                ViewBag.lista = listaSexo;
                return View(oCliente);
            }
            using (var db = new Tid81dContext())
            {
                Cliente cliente = new Cliente();
                cliente.Nombre=oCliente.Nombre;
                cliente.APaterno=oCliente.APaterno;
                cliente.AMaterno=oCliente.AMaterno;
                cliente.Direccion=oCliente.Direccion;
                cliente.Sexo=oCliente.Sexo;
                cliente.Telefono=oCliente.Telefono;
                db.Clientes.Add(cliente);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}