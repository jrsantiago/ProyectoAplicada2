using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VentanaGzWeb.Consultas
{
    public partial class ConsultaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }
        public void ObtenerValor(Productos pro)
        {
          DescripcionTextBox.Text = pro.Descripcion;
          PieTextBox.Text = Convert.ToString(pro.Pie);
          MinimoPieTextBox.Text = Convert.ToString(pro.Pie);
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Productos pro = new Productos();
            string Text = "";
            string Condicion = "";
            if(ProductoDropDownList.Text=="Descripción")
            {
                Text = " where P.Descripcion = ";
                Condicion = BuscarTextBox.Text;
                pro.ObtenerProducto(BuscarTextBox.Text);
               
            }
            else if(ProductoDropDownList.Text == "Producto Id")
            {
              
                Text = " where P.ProductoId = ";
                Condicion = BuscarTextBox.Text;
                pro.ProductoId = Convert.ToInt32(BuscarTextBox.Text);
            }
            else
            {
                 Text = "--";
                Condicion = "--";

            }
           
         if(pro.Buscar(pro.ProductoId))
            {
                ObtenerValor(pro);
            }
                

            ProductoGridView.DataSource = pro.Listado("*", Text, Condicion);
            ProductoGridView.DataBind();

           
        }
    }
}