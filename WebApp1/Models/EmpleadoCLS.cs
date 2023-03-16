using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class EmpleadoCLS
    {
        [Display(Name = "Id cliente")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud es de 50")]
        public String? Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud es de 50")]
        public String? APaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud es de 50")]
        public String? AMaterno { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(100, ErrorMessage = "La longitud es de 100")]
        public String? Email { get; set; }

        [Display(Name = "Dirección")]
        [Required]
        [StringLength(100, ErrorMessage = "La longitud es de 100")]
        public String? Direccion { get; set; }
        [Display(Name = "Sexo")]
        public int? Sexo { get; set; }

        [Display(Name = "Telefono")]
        [Required]
        [StringLength(16, ErrorMessage = "La longitud es de 16")]
        public String? Telefono { get; set; }

        [Display (Name= "Fecha Contrato")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy:mm:dd}",ApplyFormatInEditMode = true)]
        public DateOnly? FechaContrato { get; set; }

        [Display (Name = "Sueldo")]
        [Required]
        public decimal? Sueldo { get; set; }
        //  Agregasmos los atributos de  tipoCXontrato y tipoUsuario al modelo
        [Display(Name = "Tipo de contrato")]
        [Required]
        public int? TipoContrato { get; set; }
        [Display(Name = "Tipo de usuario")]
        [Required]
        public int? TipoUsuario { get; set; }

        //Campos para las descripciones
        
        public String? NombreTipoContrato { get; set; }
        public String? NombreTipoUsuario { get; set; }
        public String? NombreSexo { get; set; }
    }
}   