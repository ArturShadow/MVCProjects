﻿using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class ProductoCLS
    {
        [Display(Name = "Clave Producto")]
        public int IdProducto { get; set; }
        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }

        [Display(Name = "Precio")]
        public decimal? Precio { get; set; }

        [Display(Name = "Inventario")]
        public int? Inventario { get; set; }
    }
}