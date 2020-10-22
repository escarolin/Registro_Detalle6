using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows.Markup;

namespace Registro_Detalle6.Entidades
{
    public class Productos
    {    [Key]
        public int ProductoId { get; set; }
        public string  Descripcion { get; set; }
        public double Costop { get; set; }
        public double Inventario { get; set; }

      

    }
}
