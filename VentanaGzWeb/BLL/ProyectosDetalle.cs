using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ProyectosDetalle
    {
        public int ProyectoDetalleId { get; set; }
        public int ProyectoId { get; set; }
        public string Descripcion { get; set; }
        public float Pie { get; set; }
        public float Ancho { get; set; }
        public float Altura { get; set; }
        public int Cantidad { get; set; }
        public float  Precio { get; set; }
        
        public ProyectosDetalle(int ProyectoId,string Descripcion,float Ancho,float Altura,int Cantidad,float Pie,float Precio)
        {
            this.Descripcion = Descripcion;
            this.Ancho = Ancho;
            this.Altura = Altura;
            this.Pie = Pie;
            this.Cantidad = Cantidad;
            this.Precio = Precio;

        }

        public ProyectosDetalle()
        {
            this.ProyectoDetalleId = 0;
            this.ProyectoId = 0;
            this.Descripcion = "";
            this.Ancho = 0;
            this.Altura = 0;
            this.Pie = 0;
            this.Cantidad = 0;
            this.Precio = 0;

        }
    }
}
