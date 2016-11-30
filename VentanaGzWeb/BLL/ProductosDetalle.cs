using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class ProductosDetalle
    {
        public int TrabajoDetalleId { get; set; }
        public int ProductoId { get; set; }
        public int MaterialId { get; set; }
        public string Detalle { get; set; }
        public int Asociacion { get; set; }
        public float Cantidad { get; set; }


        //public ProductosDetalle(string Detalle, int Asociacion)
        //{
        //    this.Detalle = Detalle;
        //    this.Asociacion = Asociacion;
        //    this.Cantidad = 0;
        //}
        public ProductosDetalle(int MaterialId, int Asociacion)
        {      
            this.MaterialId = MaterialId;       
            this.Asociacion = Asociacion;
        }
    }
}
