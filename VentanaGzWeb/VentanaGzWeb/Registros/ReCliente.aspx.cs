using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace VentanaGzWeb.Registros
{
    public partial class ReCliente : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
           
        }
        public void LLenarCampos(Clientes cli)
        {
            NombreTextBox.Text = cli.Nombre;
            TelefonoTextBox.Text = cli.Telefono;
            DireccionTextBox.Text = cli.Direccion;
            CedulaTextBox.Text = cli.Cedula;
            EmailTextBox.Text = cli.Email;
        }
        public void ObtenerDatos(Clientes cli)
        {
               cli.Nombre = NombreTextBox.Text;
               cli.Telefono = TelefonoTextBox.Text;
               cli.Direccion = DireccionTextBox.Text;
               cli.Cedula = CedulaTextBox.Text;
               cli.Email = EmailTextBox.Text;
           

        }
        public void Limpiar()
        {
            BuscarTextBox.Text = "";
            NombreTextBox.Text = "";
            DireccionTextBox.Text = "";
            CedulaTextBox.Text = "";
            EmailTextBox.Text = "";
            TelefonoTextBox.Text = "";

        }
        public int convertirId()
        {
            int id = 0;
            int.TryParse(BuscarTextBox.Text, out id);

            return id;
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
                int id = 0;
                id = convertirId();

                if(cli.Buscar(id))
                {
                    LLenarCampos(cli);

            }
            else
              {
                Utilitarios.ShowToastr(this, "Error Id", "Mensaje", "error");

             }
            }
 
        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            cli.ClienteId = convertirId();
                if(cli.Eliminar())
                {
                    Utilitarios.ShowToastr(this, "Eliminado", "Mensaje", "success");
                    Limpiar();
                }
                else
                {
                   Utilitarios.ShowToastr(this, "error", "Mensaje", "error");

                }
            
        }

        protected void GUARDARButton_Click1(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            ObtenerDatos(cli);


            if (NombreTextBox.Text == cli.ValidarCliente(NombreTextBox.Text))
            {
                Utilitarios.ShowToastr(this, "Error Nombre de Cliente", "Mensaje", "error");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
                {


                    if (cli.Insertar())
                    {

                    }

                }
                else
                {
                    cli.ClienteId = convertirId();
                    if (cli.Editar())
                    {

                    }
                }
                Utilitarios.ShowToastr(this, "Guardado", "Mensaje", "success");
            }
        }
    }
}