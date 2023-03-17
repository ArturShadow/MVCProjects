using System.ComponentModel.DataAnnotations;

namespace Tienda.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Codigo cliente")]
        public int CodCliente { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100,ErrorMessage = "El maximo de caracteres es de 100")]
        
        public string? Nombre { get; set; }

        [Display(Name = "Apellidos")]
        [Required]
        [StringLength(100,ErrorMessage = "El maximo de caracteres es de 100")]
        public string? Apellidos { get; set; }

        [Display(Name = "Empresa")]
        [Required]
        [StringLength(100,ErrorMessage = "El maximo de caracteres es de 100")]
        public string? Empresa { get; set; }

        [Display(Name = "Puesto")]
        [Required]
        [StringLength(100,ErrorMessage = "El maximo de caracteres es de 100")]
        public string? Puesto { get; set; }
        [Display(Name = "Codigo Postal")]
        [Required]
        [StringLength(100,ErrorMessage = "El maximo de caracteres es de 100")]
        public string? Cp { get; set; }

        [Display(Name = "Provincia")]
        [Required]
        [StringLength(100,ErrorMessage = "El maximo de caracteres es de 100")]
        public string? Provincia { get; set; }

        [Display(Name = "Telefono")]
        [Required]
        [StringLength(100,ErrorMessage = "El maximo de caracteres es de 100")]
        public string? Telefono { get; set; }

        [Display(Name = "Fecha Nacimiiento")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy:mm:dd}",ApplyFormatInEditMode = true)]
        public DateOnly? FehaNacimiento { get; set; }
    }
}