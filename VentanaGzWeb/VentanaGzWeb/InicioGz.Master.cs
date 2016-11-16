using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Threading;

namespace VentanaGzWeb
{
    public partial class InicioGz : System.Web.UI.MasterPage
    {
        delegate void dele(Label texto,int laY, int Vel);
        protected void Page_Load(object sender, EventArgs e)
        {
           

            //Thread[] hilos = new Thread[1];
            //for(int i =0;i<hilos.Length;i++)
            //{
            //    hilos[i] = new Thread(metodo);
            //    hilos[1].Name = "h" + 1;
            //    hilos[i].Start();
            //}
        }
       //public void metodo()
       // {
       //     dele elDelegado = new dele(Mover);
       //     if (Thread.CurrentThread.Name.Equals("h0"))
       //     {
       //        // elDelegado.Invoke(InformacionLabel,);
       //     }
       // }
        //public void Mover(Label texto,int laY, int Velocidad)
        //{
        //    for(int i =0; 1<500;i++)
        //    {
        //      //  texto.
        //    }
        //}

      
    }
}