namespace Ventas.Domain.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Ventas.Common.Models.Producto> Productoes { get; set; }
    }
}
