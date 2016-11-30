using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VentanaGzWeb.Registros
{
    public partial class RUsuario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }

        }
        public void ObtenereDatos(Usuario usu)
        {
         
            if (usu.Restriccion == 0)
            {
                RestriccionDropDownList.Text = "Administrador";
            }
            else
            {
                RestriccionDropDownList.Text = "Usuario";
            }
            UserNameTextBox.Text = usu.UserName;
            ContrasenaTextBox.Text = usu.Contrasena;
            NombreTextBox.Text = usu.Nombre;

        }
        public void LlenarValor(Usuario usu)
        {
         
           usu.Restriccion = RestriccionDropDownList.SelectedIndex;
          
            string str = FotoUpload.FileName;

            if (str != "")
            {
                FotoUpload.PostedFile.SaveAs(Server.MapPath("//Imagenes//") + str);
                string path = "~//Imagenes//" + str.ToString();

                usu.Imagenes = path;
            }
            usu.UserName = UserNameTextBox.Text;
            usu.Contrasena = ContrasenaTextBox.Text;
            usu.Nombre = NombreTextBox.Text;         
           
        }
        public int ConvertirId()
        {
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);

            return id;
        }
        public void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            ContrasenaTextBox.Text = string.Empty;
            UserNameTextBox.Text = string.Empty;
            RepitContrasenaTextBox.Text = string.Empty;
        }
     

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();

            if (usu.Buscar(ConvertirId()))
            {
                ObtenereDatos(usu);
            }
            else
            {
                Utilitarios.ShowToastr(this, "Error Id", "Mensaje", "error");
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();


            
                LlenarValor(usu);
                if (usu.ValidarUserNombre(UserNameTextBox.Text) == UserNameTextBox.Text)
                {
                    Utilitarios.ShowToastr(this, "Error Nombre Usuario", "Mensaje", "error");

                }
                else if (usu.ValidarContrasena(ContrasenaTextBox.Text) == ContrasenaTextBox.Text)
                {
                    Utilitarios.ShowToastr(this, "Error Contraseña", "Mensaje", "error");

                }
                else
                {

                    if (IdTextBox.Text == "")
                    {

                        if (usu.Insertar())
                        {
                            
                        }
                    }
                    else
                    {
                   
                    usu.UsuarioId = ConvertirId();
                        if (usu.Editar())
                        {
                            
                        }
                    }
                    Utilitarios.ShowToastr(this, "Guardado", "Mensaje", "success");
                }
            
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
           
               
                usu.UsuarioId = ConvertirId();
                usu.Eliminar();
            Utilitarios.ShowToastr(this, "Eliminado", "Mensaje", "success");
            Limpiar();
            
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
    }
}