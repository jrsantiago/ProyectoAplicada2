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
using System.Data;

namespace VentanaGzWeb
{
    public partial class InicioGz : System.Web.UI.MasterPage
    {
        delegate void dele(Label texto,int laY, int Vel);
        public int Restriccion { get; set; }
        public string UserName { get; set; }
        public InicioGz()
        {
            this.Restriccion = 3;
            this.UserName = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {

                RegistroMaster.Visible = false;
                ConsultaMaster.Visible = false;
                CerrarSeButton.Visible = true;
                LogingWeb.Visible = true;

                ControlUsuarioWeb();

            }

            
        }
     
        protected void EntrarImageButton_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = new DataTable();
            Usuario usu = new Usuario();


            if (usu.Listado("*", " where UserName='" + UserNameTextBox.Text + "' and  Contrasena ='" + ContraseñaTextBox0.Text + "'--", "--").Rows.Count > 0)
            {

                Session["Restriccion"] = Convert.ToString(usu.Restriccion);    

                this.Restriccion = usu.Restriccion;
                this.UserName = usu.UserName;
              
                ControlUsuarioWeb();

            }
           

        }
     
        public void ControlUsuarioWeb()
        {
            string resultardo = "";
            resultardo = Convert.ToString(Session["Restriccion"]);
            if(resultardo =="0")
            {
               
                RegistroMaster.Visible = true;
                ConsultaMaster.Visible = true;
                LogingWeb.Visible = false;
                CerrarSeButton.Visible = true;

            }else
            if(resultardo == "1")
            {
              
                RegistroMaster.Visible = true;
                ConsultaMaster.Visible = true;
                LogingWeb.Visible = false;
                RegistroUsuarioWeb.Visible = false;
                RegistroProductoWeb.Visible = false;
                CerrarSeButton.Visible = true;
                ConsultaUsuarioWeb.Visible = false;

            }else
            {
                RegistroMaster.Visible = false;
                ConsultaMaster.Visible = false;
                CerrarSeButton.Visible = false;
                LogingWeb.Visible = true;
            }

        }

        protected void CerrarSeButton_Click(object sender, EventArgs e)
        {
             Session["Restriccion"] = Convert.ToString(3);
             ControlUsuarioWeb();
        }

        
    }
}