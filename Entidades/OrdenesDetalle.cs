using System;
using System.ComponentModel.DataAnnotations;


namespace Registro_Detalle6.Entidades{
    public class OrdenesDetalle{
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Monto { get; set; }
    }
}