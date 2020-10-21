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
    }
}