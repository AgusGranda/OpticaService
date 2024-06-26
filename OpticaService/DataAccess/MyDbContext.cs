﻿using Microsoft.EntityFrameworkCore;
using OpticaService.Models;

namespace OpticaService.DataAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Optico> Opticos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-76KGP02\\SQLEXPRESS;Initial Catalog=Optica_DB;Persist Security Info = True;Trusted_Connection = SSPI;MultipleActiveResultSets=True; Trust Server Certificate= True");
        }

    }
}
