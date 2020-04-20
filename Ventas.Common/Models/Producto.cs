namespace Ventas.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Producto
    {
        [Key]
        public int IDProducto { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime FechaPublicacion { get; set; }
    }
}
