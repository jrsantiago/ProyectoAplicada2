using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace VentanaGzWeb.Consultas
{
    public partial class ConsultaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            DbVentana cone = new DbVentana();
            Clientes cli = new Clientes();
            DataTable dt = new DataTable();
            string Text = "";
            string orden = "";

            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text) && ClienteDropDownList.Text != "Todos los Clientes")
            {
                Utilitarios.ShowToastr(this, "Error Campo Incorrecto", "Mensaje", "error");
            }
            else
            {
                if (ClienteDropDownList.Text == "Nombre")
                {
                    Text = "Where Nombre = ";
                    orden = BuscarTextBox.Text;
                }
                else if (ClienteDropDownList.Text == "Todos los Clientes")
                {
                    Text = "--";
                    orden = "--";
                }
                else if (ClienteDropDownList.Text == "Nombre")
                {
                    Text = " where Nombre = ";
                    orden = BuscarTextBox.Text;
                }
                else if (ClienteDropDownList.Text == "Id")
                {
                    Text = " where ClienteId = ";
                    orden = BuscarTextBox.Text;
                }

                else if (ClienteDropDownList.Text == "Cedula")
                {
                    Text = " where Cedula = ";
                    orden = BuscarTextBox.Text;
                }

                else if (ClienteDropDownList.Text == "Email")
                {
                    Text = " where Email = ";
                    orden = BuscarTextBox.Text;
                }

               ClienteGridView.DataSource = cli.Listado("*", Text, orden);
               ClienteGridView.DataBind();
            }


        }
    }
}
