﻿namespace Ventas.Backend.Models
{
    using Domain.Models;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Ventas.Common.Models.Producto> Productoes { get; set; }
    }
}