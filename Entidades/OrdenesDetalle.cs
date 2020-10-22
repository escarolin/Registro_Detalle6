using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Detalle6.Entidades{
    public class OrdenesDetalle{
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
        public int SuplidorId { get; set; }
        
       [ForeignKey("ProductoId")]
        public Productos Producto { get; set; } = new Productos();
       
    }
}