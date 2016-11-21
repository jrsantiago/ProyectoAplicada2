using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace VentanaGzWeb.Consultas
{
    public partial class ConsUsuario : System.Web.UI.Page
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            DbVentana cone = new DbVentana();
            Usuario usu = new Usuario();
            DataTable dt = new DataTable();
            string Text = "";
            string orden = "";
         
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text) && UsuarioDropDownList.Text != "Todos los Usuarios")
            {
                Utilitarios.ShowToastr(this, "Error Campo Incorrecto", "Mensaje", "error");
            }
            else
            {
                if (UsuarioDropDownList.Text == "Nombre")
                {
                    Text = "Where Nombre = ";
                    orden = BuscarTextBox.Text;
                }
                else if (UsuarioDropDownList.Text == "Todos los Usuarios")
                {
                    Text = "--";
                    orden = "--";
                }
                else if (UsuarioDropDownList.Text == "Nombre de Usuario")
                {
                    Text = " where UserName = ";
                    orden = BuscarTextBox.Text;
                }
                else if (UsuarioDropDownList.Text == "Id")
                {
                    Text = " where UsuariosId = ";
                    orden= BuscarTextBox.Text;
                }

             

                DataSet ds = usu.GetData(usu.Listado("*",Text,orden));

                Repeater.DataSource = ds;
                Repeater.DataBind();
               // UsuarioImagen.Visible = false;
               

            }



        }
       
    }
}