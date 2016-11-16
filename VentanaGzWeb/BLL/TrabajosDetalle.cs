using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class TrabajosDetalle
    {
        public int TrabajoDetalleId { get; set; }
        public string Detalle { get; set; }
        public string Asociacion { get; set; }

        public TrabajosDetalle(string Detalle, string Asociacion)
        {
           
            this.Detalle = Detalle;
            this.Asociacion = Asociacion;
        }
    }
}
