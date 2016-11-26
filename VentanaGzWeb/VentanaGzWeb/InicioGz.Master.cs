using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Threading;
using DAL;
using BLL;

namespace VentanaGzWeb
{
    public partial class InicioGz : System.Web.UI.MasterPage
    {
        delegate void dele(Label texto,int laY, int Vel);
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                ErrorLabel.Visible = false;
            }
           
        }

        protected void EntrarImageButton_Click(object sender, ImageClickEventArgs e)
        {
            Usuario usu = new Usuario();

            if (usu.Listado("*", " where UserName='" + UserNameTextBox.Text + "' and  Contrasena ='" + ContraseñaTextBox0.Text + "'--", "--").Rows.Count > 0)
            {
                
            }
            else
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Contraseña o Nombre de usuario Incorrectos";
            }

        }
    }
}