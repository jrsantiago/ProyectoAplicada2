using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class Longitud
    {
        public string Trabajo { get; set; }
        public float Ancho { get; set; }
        public float Altura { get; set; }

        public Longitud(string Trabajo,float Ancho, float Altura)
        {
            this.Trabajo = Trabajo;
            this.Ancho = Ancho;
            this.Altura = Altura;
        }
      
    }
}
