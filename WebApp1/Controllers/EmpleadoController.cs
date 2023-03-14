using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WebApp1.Models;
using WebApp1.Models.DB;

namespace WebApp1.Controllers
{
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        List<SelectListItem>? listaTC;
        List<SelectListItem>? listaSexo;
        List<SelectListItem>? listaTU;
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            List<EmpleadoCLS>? listEmpleado = null;

            using (var db = new Tid81dContext())
            {
                listEmpleado = (from empleado in db.Empleados
                                join sexo in db.Sexos on empleado.Sexo equals sexo.IdSexo
                                join tipoUsuario in db.TipoUsuarios on empleado.TipoUsuario equals tipoUsuario.IdTipoUsuario
                                join tipoContrato in db.TipoContratos on empleado.TipoContrato equals tipoContrato.IdTipoContrato
                                select new EmpleadoCLS
                                {
                                    IdEmpleado = empleado.IdEmpleado,
                                    Nombre = empleado.Nombre,
                                    APaterno = empleado.APaterno,
                                    AMaterno = empleado.AMaterno,
                                    Email = empleado.Email,
                                    Direccion = empleado.Direccion,
                                    // Sexo = empleado.Sexo,
                                    NombreSexo = sexo.Descripcion,
                                    Telefono = empleado.Telefono,
                                    FechaContrato = empleado.FechaContrato,
                                    Sueldo = empleado.Sueldo,
                                    NombreTipoUsuario = tipoUsuario.Descripcion,
                                    NombreTipoContrato = tipoContrato.Descripcion
                                }).ToList();
            }
            return View(listEmpleado);
        }

        private void LlenarListaTC()
        {
            using (var db = new Tid81dContext())
            {
                listaTC = (from tipoContrato in db.TipoContratos select new SelectListItem(){
                     Text = tipoContrato.Descripcion,
                     Value = tipoContrato.IdTipoContrato.ToString()
                }).ToList();
            }
            listaTC.Insert(0, new SelectListItem { Text = "-- Selecciona --", Value = "" });
        }

        private void LlenarListaSexo()
        {
            using (var db = new Tid81dContext())
            {
                listaSexo = (from sexo in db.Sexos select new SelectListItem(){
                     Text = sexo.Descripcion,
                     Value = sexo.IdSexo.ToString()
                }).ToList();
            }
            listaSexo.Insert(0, new SelectListItem { Text = "-- Selecciona --", Value = "" });
        }

        private void LlenarListaTU()
        {
            using (var db = new Tid81dContext())
            {
                listaTU = (from tipoUsuario in db.TipoUsuarios select new SelectListItem(){
                     Text = tipoUsuario.Descripcion,
                     Value = tipoUsuario.IdTipoUsuario.ToString()
                }).ToList();
            }
            listaTU.Insert(0, new SelectListItem { Text = "-- Selecciona --", Value = "" });
        }

        private void LlenarCampos(){
            LlenarListaTC();
            LlenarListaSexo();
            LlenarListaSexo();
            
        }

        public IActionResult Agregar(){
            LlenarCampos();
            ViewBag.listaTC = listaTC;
            ViewBag.listaSexo = listaSexo;
            ViewBag.listaTU = listaTU;
            return View();
        }
    }
}