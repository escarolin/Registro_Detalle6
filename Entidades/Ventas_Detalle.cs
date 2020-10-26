using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Registro_Detalle6.Entidades{
public class Ventas_Detalle{
    [Key]
    public int Id { get; set; }

    public int VentaId { get; set; }
    public string Servicio { get; set; }
    public double Precio { get; set; }
    //[ForeignKey("VentaId")]
        //public Ventas Ventas { get; set; } = new Ventas();

}

}