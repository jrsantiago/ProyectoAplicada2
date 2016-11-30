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
        public void LlenarValor(Productos tra)
        {
           
            string asociado = "";
            DataTable dt = (DataTable)ViewState["Detalle"];

            DescripcionTextBox.Text = tra.Descripcion;
            traTextBox.Text = tra.Pie.ToString();
            MinimoPieTextBox.Text = tra.MinimoPie.ToString();


            foreach(var item in tra.Detalle)
            {
                if (item.Asociacion == 0)
                {
                    asociado = "Ancho";

                }
                else if (item.Asociacion == 1)
                {
                    asociado = "Altura";
                }else
                {
                    asociado = "Nada";
                }

                dt.Rows.Add(item.MaterialId, asociado);
                ViewState["Detalle"] = dt;
                ObtenerGrid();
            }

        }
        public void ObtenerDatos(Productos tra)
        {
            int asociado = 0;
            tra.Descripcion = DescripcionTextBox.Text;
            tra.Pie = Convert.ToSingle(traTextBox.Text);
            tra.ProductoId = ConvertirId();
            tra.MinimoPie = Convert.ToSingle(MinimoPieTextBox.Text);
            
            

            foreach(GridViewRow row in ProductoGridView.Rows)
            {
                if(row.Cells[1].Text == "Ancho")
                {
                    asociado = 0;
                }else
                 if (row.Cells[1].Text == "Altura")
                {
                    asociado = 1;
                }else
                {
                    asociado = 2;
                }
                tra.AgregarProducto(Convert.ToInt32(row.Cells[0].Text),asociado);
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

            LlenarGridView();
            ObtenerGrid();
        }
        public void LimpiarGrid()
        {
            LlenarGridView();
            ObtenerGrid();
        }
        public void ObtenerGrid()
        {
            ProductoGridView.DataSource = (DataTable)ViewState["Detalle"];
            ProductoGridView.DataBind();
        }
        public void LlenarGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("MaterialId"), new DataColumn("Relacion") });
            ViewState["Detalle"] = dt;
        }
        public void LlenarDropDownMaterial()
        {
            DataTable dt = new DataTable();
            Materiales mate = new Materiales();

            dt = mate.Listado("*", "--", "--");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                MaterialesDropDownList.Items.Add(Convert.ToString(mate.Listado("*", "--", "--").Rows[i]["Detalle"]));
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Productos tra = new Productos();
            MaterialesDropDownList.Items.Clear();
            LlenarDropDownMaterial();
         

                if(tra.Buscar(ConvertirId()))
                {
                    LimpiarGrid();
                    
                    LlenarValor(tra);

                }else
                {
                    Utilitarios.ShowToastr(this, "Error Id", "Mensaje", "error");
                }
            
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Productos tra = new Productos();
            if(ProductoGridView.Rows.Count == 0)
            {
                Utilitarios.ShowToastr(this, "ERROR (Campos Vacios) -- Agregar Materiales", "Mensaje", "error");

            }
            else
            {
                ObtenerDatos(tra);
                if (BuscarTextBox.Text == "")
                {
                    if(tra.Insertar())
                    {
                        
                    }

                }else
                {
                    tra.ProductoId = ConvertirId();
                    if(tra.Editar())
                    {
                        
                    }
                }
                Utilitarios.ShowToastr(this, "Guardado", "Mensaje", "success");
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Productos tra = new Productos();
        
                tra.ProductoId = ConvertirId();
                if(tra.Eliminar())
                {                    
                   
                    Utilitarios.ShowToastr(this, "Eliminado", "Mensaje", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this, "Error Id", "Mensaje", "error");
                }
                Limpiar();
            }
        
        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Materiales mate = new Materiales();

            try {
                  DataTable dt = (DataTable)ViewState["Detalle"];
                  DataRow row;

                  row = dt.NewRow();

                mate.ObtenerValor(MaterialesDropDownList.Text);
                row["MaterialId"] = mate.MaterialId;
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