using Microsoft.AspNetCore.Mvc;
using WebApp1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace WebApp1.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {

        public IActionResult Index()
        {
            List<Cliente>? listaCliente = null;

            using (var db = new Models.DB.Tid81dContext())
            {
                listaCliente = (from cliente in db.Clientes
                                select new Cliente
                                {
                                    IdCliente = cliente.IdCliente,
                                    Nombre = cliente.Nombre,
                                    APaterno = cliente.APaterno,
                                    AMaterno = cliente.AMaterno,
                                    Email = cliente.Email,
                                    Direccion = cliente.Direccion,
                                    Sexo = (int) cliente.Sexo,
                                    Telefono = cliente.Telefono
                                }).ToList();
            }
            return View(listaCliente);
        }
        //Llenar el combobox de Sexo
        List<SelectListItem>? listaSexo;
        private void LlenarSexo(){
            using (var db = new Models.DB.Tid81dContext())
            {
                listaSexo = (from sexo in db.Sexos select new SelectListItem {
                    Text = sexo.Descripcion,
                    Value = sexo.IdSexo.ToString()
                }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "-- Selecciona --",Value=""});
            }
        }
    }
}