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
            float.TryParse(txtCantidad.Text,out cantidad);
            float.TryParse(txtPrecio.Text, out precio);

            mate.Detalle = txtDetalle.Text;
            mate.Unidad = txtUnidad.Text;
            mate.Cantidad = cantidad;
            mate.Precio = precio;
           
        }
        public void LlenarDatos(Materiales mate)
        {
            txtDetalle.Text = mate.Detalle;
            txtUnidad.Text = mate.Unidad;
            txtCantidad.Text = mate.Cantidad.ToString();
            txtPrecio.Text = mate.Precio.ToString();

        }
        public int ConvertirId()
        {
            int id = 0;

            int.TryParse(txtIdMateriales.Text, out id);
            return id;

        }
        public void Limpiar()
        {
            txtIdMateriales.Text = "";
            txtDetalle.Text = "";
            txtUnidad.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Materiales mate = new Materiales();

          ObtenerDatos(mate);
            if(txtIdMateriales.Text=="")
            {
              
                if(mate.Insertar())
                {
                    Utilitarios.ShowToastr(this, "Guardado", "Mensaje", "success");
                }
            }else
            {
                mate.MaterialId = ConvertirId();
                if (mate.Editar())
                {
                    Utilitarios.ShowToastr(this, "Guardado", "Mensaje", "success");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Materiales mate = new Materiales();

            mate.MaterialId = ConvertirId();
                if(mate.Eliminar())
                {
                  Utilitarios.ShowToastr(this, "Eliminado", "Mensaje", "success");
                  Limpiar();
                }
            
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Materiales mate = new Materiales();
 
         if (mate.Buscar(ConvertirId()))
             {
                    LlenarDatos(mate);
            }
            else
            {
                Utilitarios.ShowToastr(this, "Error Id", "Mensaje", "error");
            }
            
        }
    }
}