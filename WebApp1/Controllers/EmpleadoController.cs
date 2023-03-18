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
        List<EmpleadoCLS>? listEmpleado;
        List<SelectListItem>? listaTC;
        List<SelectListItem>? listaSexo;
        List<SelectListItem>? listaTU;
        [HttpGet("[action]")]
        public IActionResult Index()
        {

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
            LlenarListaTU();
            ViewBag.listaTC = listaTC;
            ViewBag.listaSexo = listaSexo;
            ViewBag.listaTU = listaTU;
        }
        [HttpGet("[action]")]
        public IActionResult Agregar(){
            LlenarCampos();
        
            return View();
        }
        [HttpPost("[action]")]
        public IActionResult Agregar(EmpleadoCLS oEmpleado){
            if(!ModelState.IsValid){
                LlenarCampos();
                return View(oEmpleado);
            }
            using(var db = new Tid81dContext()){
                Empleado empleado = new Empleado();
                empleado.IdEmpleado = oEmpleado.IdEmpleado;
                empleado.Nombre = oEmpleado.Nombre;
                empleado.APaterno = oEmpleado.APaterno;
                empleado.AMaterno = oEmpleado.AMaterno;
                empleado.Direccion = oEmpleado.Direccion;
                empleado.Email = oEmpleado.Email;
                empleado.Sexo = oEmpleado.Sexo;
                empleado.Telefono = oEmpleado.Telefono;
                empleado.FechaContrato = oEmpleado.FechaContrato;
                empleado.Sueldo = oEmpleado.Sueldo;
                empleado.TipoContrato = oEmpleado.TipoContrato;
                empleado.TipoUsuario = oEmpleado.TipoUsuario;
                db.Empleados.Add(empleado);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost("[action]")]
        public IActionResult Editar(int id)
        {
            LlenarCampos();
            EmpleadoCLS oEmpleado = new EmpleadoCLS();
            using(var db = new Tid81dContext()){
                Empleado empleado = db.Empleados.Where(p => p.IdEmpleado.Equals(id)).First();
                oEmpleado.Nombre = empleado.Nombre;
                oEmpleado.APaterno = empleado.APaterno;
                oEmpleado.AMaterno = empleado.AMaterno;
                oEmpleado.Direccion = empleado.Direccion;
                oEmpleado.Email = empleado.Email;
                oEmpleado.Sexo = empleado.Sexo;
                oEmpleado.Telefono = empleado.Telefono;
                oEmpleado.FechaContrato = empleado.FechaContrato;
                oEmpleado.Sueldo = empleado.Sueldo;
                oEmpleado.TipoContrato = empleado.TipoContrato;
                oEmpleado.TipoUsuario = empleado.TipoUsuario;
            }
            return View(oEmpleado);
        }
    }
}