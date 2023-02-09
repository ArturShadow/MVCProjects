using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class ClienteCLS
    {
        [Display (Name ="Id Cliente")]
        [Required]
        public int IdCliente { get; set; }
        [Required]
        [Display(Name = "Nombre cliente")]
        [StringLength(50,ErrorMessage ="No puede escribir mas de 50 caracteres")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(50,ErrorMessage ="No puede escribir mas de 50 caracteres")]
        public string APaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(50,ErrorMessage ="No puede escribir mas de 50 caracteres")]
        public string AMaterno { get; set; }

        
        [Display(Name = "Email")]
        [Required]
        [StringLength(100,ErrorMessage ="No puede escribir mas de 100 caracteres")]
        public string Email { get; set; }
        [Display(Name = "Correo")]
        [Required]
        [StringLength(100,ErrorMessage ="No puede escribir mas de 100 caracteres")]
        public string Direccion { get; set; }
        // [Display(Name = "Genero")]
        // [Required]
        //  public int Sexo { get; set; }

        [Display(Name="Telefono del cliente")]
        [Required]
        public string Telefono { get; set; }
    }
}