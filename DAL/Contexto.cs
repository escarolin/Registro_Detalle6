using Microsoft.EntityFrameworkCore;
using Registro_Detalle6.Entidades;

namespace Registro_Detalle6.DAL
{
    public class Contexto : DbContext
    {
       
        public DbSet<Ordenes> Ordenes { get; set; }
         public DbSet<Suplidores> Suplidores { get; set; }

             public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\Pedidos.db");
        }

     
      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productos>().HasData(new Productos
            { ProductoId = 1, Descripcion = "Manzana", Costop = 55.5, Inventario = 57 });
            modelBuilder.Entity<Productos>().HasData(new Productos 
            { ProductoId = 2, Descripcion = "Cerveza", Costop = 30.95, Inventario = 53 });
             modelBuilder.Entity<Productos>().HasData(new Productos 
            { ProductoId = 3, Descripcion = "Leche", Costop = 45.00, Inventario = 30 });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores 
            { SuplidorId = 1, Nombres = "PorVnir" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores 
            { SuplidorId = 2, Nombres = "Presidente" });
             modelBuilder.Entity<Suplidores>().HasData(new Suplidores 
            { SuplidorId = 3, Nombres = "Nestle" });
        }

    }
}