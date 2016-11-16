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
    public partial class ReVentatra : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridView();
            }
            LlenarDropDownMaterial();
        }
        public void LlenarValor(Trabajos tra)
        {
            DataTable dt = (DataTable)ViewState["Detalle"];

            DescripcionTextBox.Text = tra.Descripcion;
            traTextBox.Text = tra.Pie.ToString();
            MinimoPieTextBox.Text = tra.MinimoPie.ToString();


            foreach(var item in tra.Detalle)
            {
                dt.Rows.Add(item.Detalle, item.Asociacion);
                ViewState["Detalle"] = dt;
                ObtenerGrid();
            }

        }
        public void ObtenerDatos(Trabajos tra)
        {
            tra.Descripcion = DescripcionTextBox.Text;
            tra.Pie = Convert.ToSingle(traTextBox.Text);
            tra.TrabajoId = ConvertirId();
            tra.MinimoPie = Convert.ToSingle(MinimoPieTextBox.Text);

            foreach(GridViewRow row in TrabajoGridView.Rows)
            {
                tra.AgregarTrabajo(row.Cells[0].Text,row.Cells[1].Text);
            }
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
            DescripcionTextBox.Text = "";
            traTextBox.Text = "";
            MinimoPieTextBox.Text = "";

            TrabajoGridView.DataSource = null;
            TrabajoGridView.DataBind();

        }
        public void ObtenerGrid()
        {
            TrabajoGridView.DataSource = (DataTable)ViewState["Detalle"];
            TrabajoGridView.DataBind();
        }
        public void LlenarGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Material"), new DataColumn("Relacion") });
            ViewState["Detalle"] = dt;
        }
        public void LlenarDropDownMaterial()
        {
            DataTable dt = new DataTable();
            Materiales mate = new Materiales();

            dt = mate.Listado("*", "0=0", "ORDER BY Detalle");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                MaterialesDropDownList.Items.Add(Convert.ToString(mate.Listado("*", "0=0", "ORDER BY Detalle").Rows[i]["Detalle"]));
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Trabajos tra = new Trabajos();
            MaterialesDropDownList.Items.Clear();
            LlenarDropDownMaterial();
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                //BuscarBacio
            }else
            {

                if(tra.Buscar(ConvertirId()))
                {
                    LlenarValor(tra);

                }else
                {
                    Response.Write("<script>alert('Id No Existe')</script>");
                }
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Trabajos tra = new Trabajos();
            if(string.IsNullOrWhiteSpace(DescripcionTextBox.Text) || string.IsNullOrWhiteSpace(traTextBox.Text))
            {

            }else
            {
                ObtenerDatos(tra);
                if (BuscarTextBox.Text == "")
                {
                    if(tra.Insertar())
                    {
                        Response.Write("<script>alert('Guardado')</script>");
                    }

                }else
                {
                    tra.TrabajoId = ConvertirId();
                    if(tra.Editar())
                    {
                        Response.Write("<script>alert('Datos Actualizados')</script>");
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Trabajos tra = new Trabajos();
            if(string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                //Mensaje De Bacio
            }else
            {
                tra.TrabajoId = ConvertirId();
                if(tra.Eliminar())
                {                    
                    Limpiar();
                    Response.Write("<script>alert('Eliminado')</script>");
                }else
                {
                    Response.Write("<script>alert('Id No Existe')</script>");
                }
                Limpiar();
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            try {
                  DataTable dt = (DataTable)ViewState["Detalle"];
                  DataRow row;

                  row = dt.NewRow();

                  row["Material"] = MaterialesDropDownList.Text;
                  row["Relacion"] = RelacionlDropDownList0.Text;
                  dt.Rows.Add(row);
                  ViewState["Detalle"] = dt;

                  ObtenerGrid();
                  MaterialesDropDownList.Items.Clear();
                  LlenarDropDownMaterial();

            } catch(Exception ex)
            {
                throw ex;
            }
          
            
        }
    }
}