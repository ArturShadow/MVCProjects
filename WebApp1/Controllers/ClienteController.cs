using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using WebApp1.Models.DB;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace WebApp1.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {
    
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            List<ClienteCLS> listaCliente;

            using (var db = new Tid81dContext())
            {
                listaCliente = (from cliente in db.Clientes
                                join sexo in db.Sexos on cliente.Sexo equals sexo.IdSexo
                                select new ClienteCLS
                                {
                                    IdCliente = cliente.IdCliente,
                                    Nombre = cliente.Nombre,
                                    APaterno = cliente.APaterno,
                                    AMaterno = cliente.AMaterno,
                                    Email = cliente.Email,
                                    Direccion = cliente.Direccion,
                                    Descripcion = sexo.Descripcion,
                                    Telefono = cliente.Telefono,
                                    
                                }).ToList();
            }
            return View(listaCliente);
        }
        //Llenar el combobox de Sexo
        List<SelectListItem>? listaSexo;
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

        [HttpGet("[action]")]
        public IActionResult Agregar()
        {
            // Llamamos al metodo LlenarSexo
            LlenarSexo();
            // Le pasamos la lista de sexos a la vista
            ViewBag.lista = listaSexo;
            return View();
        }

        
        [HttpPost("[action]")]
        public IActionResult Agregar(ClienteCLS oCliente)
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
                cliente.Nombre = oCliente.Nombre;
                cliente.APaterno = oCliente.APaterno;
                cliente.AMaterno = oCliente.AMaterno;
                cliente.Direccion = oCliente.Direccion;
                cliente.Sexo = oCliente.Sexo;
                cliente.Telefono = oCliente.Telefono;
                cliente.Email = oCliente.Email;
                db.Clientes.Add(cliente);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}