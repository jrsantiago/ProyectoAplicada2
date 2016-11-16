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
        public bool Validar()
        {
            bool Retornar = false;
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text) || string.IsNullOrWhiteSpace(ContrasenaTextBox.Text) || string.IsNullOrWhiteSpace(UserNameTextBox.Text))
            {
                Retornar = true;
            }
            return Retornar;
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

            if (Validar())
            {
                //Llenar Todos los Campos... 
                //Enel dice que si se configura y lo busco aparece de nuevo
            }
            else
            {
                LlenarValor(usu);
                if (usu.ValidarUserNombre(UserNameTextBox.Text) == UserNameTextBox.Text)
                {
                    Response.Write("<script>alert('Error Nombre Usuario Intente otro Nombre')</script>");

                }
                else if (usu.ValidarContrasena(ContrasenaTextBox.Text) == ContrasenaTextBox.Text)
                {
                    Response.Write("<script>alert('Error Contraseña')</script>");

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
                            Response.Write("<script>alert('Guardado')</script>");
                        }
                    }
                    else
                    {
                      
                        if (usu.Editar())
                        {
                            Response.Write("<script>alert('Actualizado')</script>");
                        }
                    }

                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Response.Write("<script>alert('Introdusca un Id')</script>");
            }
            else
            {
               
                usu.UsuarioId = ConvertirId();
                usu.Eliminar();
                Response.Write("<script>alert('Eliminado')</script>");
                Limpiar();
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
    }
}