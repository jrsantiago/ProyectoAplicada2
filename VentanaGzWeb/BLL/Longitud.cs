using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class Longitud
    {
        public string Unidad { get; set; }
        public float Ancho { get; set; }
        public float Altura { get; set; }

        public Longitud(string Unidad,float Ancho, float Altura)
        {
            this.Unidad = Unidad;
            this.Ancho = Ancho;
            this.Altura = Altura;
        }
      
    }
}
