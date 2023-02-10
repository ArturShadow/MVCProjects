using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class ClienteCLS //Clase cliente que es la representacion de la tabla Clientes en la base de datos
    {
        [Display(Name = "Id Cliente")] // Nombre que se va a visualizar al momento de mostrar los datos
        [Required] //Hace que el campo sea requerido al momento de insrtar un nuevo campo en la base de datos
        public int IdCliente { get; set; }
        [Required]
        [Display(Name = "Nombre cliente")]
        [StringLength(50, ErrorMessage = "No puede escribir mas de 50 caracteres")] //Limita el numero de cvarecetes permitos, sino manda un error
        public string? Nombre { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(50, ErrorMessage = "No puede escribir mas de 50 caracteres")]
        public string? APaterno { get; set; } //Nota: el simbolo de '?' despues del tipo hace que el campo pueda ser nulo

        [Display(Name = "Apellido Materno")]
        [Required]
        [StringLength(50, ErrorMessage = "No puede escribir mas de 50 caracteres")]
        public string? AMaterno { get; set; }


        [Display(Name = "Email")]
        [Required]
        [StringLength(100, ErrorMessage = "No puede escribir mas de 100 caracteres")]
        public string? Email { get; set; }
        [Display(Name = "Correo")]
        [Required]
        [StringLength(100, ErrorMessage = "No puede escribir mas de 100 caracteres")]
        public string? Direccion { get; set; }
        // [Display(Name = "Genero")]
        // [Required]
        //  public int Sexo { get; set; }

        [Display(Name = "Telefono del cliente")]
        [Required]
        public string? Telefono { get; set; }
    }
}