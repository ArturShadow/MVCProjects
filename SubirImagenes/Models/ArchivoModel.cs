using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SubirImagenes.Models
{
    public class ArchivoModel
    {
        [Display(Name = "Archivo")]
        public IFormFile? Archivo { get; set; }
        public String? Texto { get; set; }
    }
}