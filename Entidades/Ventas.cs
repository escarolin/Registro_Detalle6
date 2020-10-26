using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Registro_Detalle6.Entidades{

public class Ventas{
    [Key]
    public int VentaId { get; set; }
    public DateTime Fecha { get; set; }
    public double Monto { get; set; }

     [ForeignKey("VentaId")]
        public virtual List<Ventas_Detalle> Detalle { get; set; } = new List<Ventas_Detalle>();


}


}