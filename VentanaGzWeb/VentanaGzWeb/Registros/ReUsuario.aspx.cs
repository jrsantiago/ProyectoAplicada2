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
         
            if (usu.Restriccion == 1)
            {
                RestriccionDropDownList.Text = "Administrador";
            }
            else
            {
                RestriccionDropDownList.Text = "Usuario";
            }
            NombreTextBox.Text = usu.UserName;
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
            usu.UserName = NombreTextBox.Text;
            usu.Contrasena = ContrasenaTextBox.Text;
            usu.Nombre = NombreTextBox.Text;         
            usu.UsuarioId =   ConvertirId();
        }
        public int ConvertirId()
        {
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);

            return id;
        }
        public void Limpiar()
        {
            IdTextBox.Text = "";
            NombreTextBox.Text = "";
            ContrasenaTextBox.Text = "";
            NombreTextBox.Text = "";
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
                Response.Write("<script>alert('Debe insertar un Id')</script>");
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();

        
           
            
                LlenarValor(usu);
                if (usu.ValidarUserNombre(UserNameTextBox.Text) == UserNameTextBox.Text)
                {
                    Utilitarios.ShowToastr(this, "Error Nombre Usuario Intente Con Otro", "Mensaje", "error");

                }
                else if (usu.ValidarContrasena(ContrasenaTextBox.Text) == ContrasenaTextBox.Text)
                {
                    Utilitarios.ShowToastr(this, "Error Contraseña Intente Otra Contraseña", "Mensaje", "error");

                }
                else if (ContrasenaTextBox.Text != RepitContrasenaTextBox.Text)
                {

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