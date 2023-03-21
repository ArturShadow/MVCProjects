using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Tienda.Views.Compra
{
    public class Agregar : PageModel
    {
        private readonly ILogger<Agregar> _logger;

        public Agregar(ILogger<Agregar> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}