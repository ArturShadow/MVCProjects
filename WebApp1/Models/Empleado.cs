using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Empleado
    {
        [Required]
        [Display(Name = "Id cliente")]
        public int IdEmpleado { get; set; }

        [Required]
        [Display(Name = "Nombre cliente")]
        [StringLength(50, ErrorMessage = "No puede escribir mas de 50 caracteres")]
        public string? Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido paterno")]
        [StringLength(50, ErrorMessage = "No puede escribir mas de 50 caracteres")]

        
        public string? APaterno { get; set; }

        [Required]
        [Display(Name = "Apellido materno")]
        [StringLength(50, ErrorMessage = "No puede escribir mas de 50 caracteres")]
        public string? AMaterno { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "No puede escribir mas de 50 caracteres")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        [StringLength(100, ErrorMessage = "No puede escribir mas de 50 caracteres")]
        public string? Direccion { get; set; }

        public int? Sexo { get; set; }

        public string? Telefono { get; set; }

        public DateTime? FechaContrato { get; set; }

        public decimal? Sueldo { get; set; }

    }
}