using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SubirImagenes.Models;

namespace SubirImagenes.Controllers
{
    [Route("[controller]")]
    public class ArchivoController : Controller
    {
        private readonly IWebHostEnvironment? webHost;

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        // [HttpPost("[action]")]
        //         public IActionResult Save(ArchivoModel model, IWebHostEnvironment webHost)
        //         {
        //             var path = webHost.ContentRootPath;
        //             var pzthArch = Path.Combine(path,"images\\archivo.jpg");
        //             if(!ModelState.IsValid) return View("Index",model);
        //             // model.Archivo.
        //             return RedirectToAction("Index");
        //         }
    }
}