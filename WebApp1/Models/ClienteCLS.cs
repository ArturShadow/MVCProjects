using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WebApp1.Models
{
    public class ClienteCLS
    {
        [Display (Name = "Id cliente")]
        public int IdCliente { get; set; }
        
        [Display (Name = "Nombre")]
        [Required]
        [StringLength(50,ErrorMessage = "La longitud es de 50")]
        public String? Nombre { get; set; }

        [Display (Name = "Apellido Paterno")]
        [Required]
        [StringLength(50,ErrorMessage = "La longitud es de 50")]
        public String? APaterno { get; set; }

        [Display (Name = "Apellido Materno")]
        [Required]
        [StringLength(50,ErrorMessage = "La longitud es de 50")]
        public String? AMaterno { get; set; }

        [Display (Name = "Email")]
        [Required]
        [StringLength(100,ErrorMessage = "La longitud es de 100")]
        public String? Email { get; set; }

        [Display (Name = "Dirección")]
        [Required]
        [StringLength(100,ErrorMessage = "La longitud es de 100")]
        public String? Direccion { get; set; }
        [Display (Name = "Sexo")]
        public int? Sexo { get; set; }

        [Display (Name = "Telefono")]
        [Required]
        [StringLength(16,ErrorMessage = "La longitud es de 16")]
        public String? Telefono  { get; set; }
    }
}