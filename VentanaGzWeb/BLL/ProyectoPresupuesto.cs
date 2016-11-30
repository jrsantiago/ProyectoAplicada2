using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ProyectoPresupuesto
    {
        public int ProyectoConduseId { get; set; }
        public int ProyectoDetalleId { get; set; }
        public int MaterialId { get; set; }
        public float Cantidad { get; set; }
        public ProyectoPresupuesto(int ProyectoDetalleId, int MaterialId, float Cantidad)
        {
            this.ProyectoDetalleId = ProyectoDetalleId;
            this.MaterialId = MaterialId;
            this.Cantidad = Cantidad;

        }

    }

}
