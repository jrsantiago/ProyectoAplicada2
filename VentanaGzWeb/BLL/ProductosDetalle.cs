using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class ProductosDetalle
    {
        public int TrabajoDetalleId { get; set; }
        public string Detalle { get; set; }
        public int Asociacion { get; set; }

        public ProductosDetalle(string Detalle, int Asociacion)
        {
           
            this.Detalle = Detalle;
            this.Asociacion = Asociacion;
        }
    }
}
