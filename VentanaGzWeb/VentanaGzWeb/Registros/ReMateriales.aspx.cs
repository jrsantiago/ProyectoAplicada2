using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace VentanaGzWeb.Registros
{
    public partial class ReMateriales : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }
        public void ObtenerDatos(Materiales mate)
        {
            float cantidad = 0;
            float precio = 0;
            float.TryParse(CantidadTextBox.Text,out cantidad);
            float.TryParse(PrecioTextBox.Text, out precio);

            mate.Detalle = DetalleTextBox.Text;
            mate.Unidad = UnidadTextBox.Text;
            mate.Cantidad = cantidad;
            mate.Precio = precio;
            mate.MaterialId = ConvertirId();
        }
        public void LlenarDatos(Materiales mate)
        {
            DetalleTextBox.Text = mate.Detalle;
            UnidadTextBox.Text = mate.Unidad;
            CantidadTextBox.Text = mate.Cantidad.ToString();
            PrecioTextBox.Text = mate.Precio.ToString();

        }
        public int ConvertirId()
        {
            int id = 0;

            int.TryParse(BuscarTextBox.Text, out id);
            return id;

        }
        public void Limpiar()
        {
            BuscarTextBox.Text = "";
            DetalleTextBox.Text = "";
            UnidadTextBox.Text = "";
            CantidadTextBox.Text = "";
            PrecioTextBox.Text = "";
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Materiales mate = new Materiales();

            if (string.IsNullOrWhiteSpace(DetalleTextBox.Text) || string.IsNullOrWhiteSpace(UnidadTextBox.Text) || string.IsNullOrWhiteSpace(CantidadTextBox.Text) || string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                Response.Write("<script>alert('LLene Todos los Campos')</script>");
            }
            else if(BuscarTextBox.Text=="")
            {
                ObtenerDatos(mate);
                if(mate.Insertar())
                {
                    Response.Write("<script>alert('Guardado')</script>");
                }
            }else
            {
                ObtenerDatos(mate);
                if(mate.Editar())
                {
                    Response.Write("<script>alert('Editado')</script>");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Materiales mate = new Materiales();
            if(string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                Response.Write("<script>alert('Introdusca Id')</script>");
            }
            else
            {
                if(mate.Eliminar())
                {
                    Response.Write("<script>alert('Eliminado')</script>");
                    Limpiar();
                }
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Materiales mate = new Materiales();
           
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                Response.Write("<script>alert('Introdusca Id')</script>");
            }
            else
            {

                if (mate.Buscar(ConvertirId()))
                {
                    LlenarDatos(mate);
                }
            }
        }
    }
}