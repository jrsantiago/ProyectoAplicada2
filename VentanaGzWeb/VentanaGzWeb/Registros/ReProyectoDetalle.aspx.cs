using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VentanaGzWeb.Registros
{
    public partial class ReProyectoDetalle : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
      
            if (!IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("dd/MM/yy");
                FechaTextBox.ReadOnly = true;
                AddColumnas();
            }

            LlenarDrowList();

        }
        public int ConvertirId()
        {
            int id = 0;
            int.TryParse(BuscarClienteTextBox.Text, out id);
            return id;
        } 
        public int ConvertirIdProyecto()
        {
            int id = 0;
            int.TryParse(BuscarIdTextBox.Text, out id);

            return id;
        }
        public float ConvertirTotal()
        {
            float Total = 0;
            float.TryParse(TotalTextBox.Text, out Total);

            return Total;
        }         
        public void AddColumnas()
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
       
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Descripcion"), new DataColumn("Ancho"), new DataColumn("Altura"), new DataColumn("Pie"), new DataColumn("Precio")});
            ViewState["Detalle"] = dt;

            dt2.Columns.AddRange(new DataColumn[4] { new DataColumn("Descripcion"), new DataColumn("AnchoTotal"), new DataColumn("AlturaTotal"), new DataColumn("PieTotal") });
            ViewState["Resumen"] = dt2;
        }     
        public void ObtenerDatosCliente(Clientes cli)
        {
            ClienteTextBox.Text = cli.Nombre;
        }
        public void ObtenerGridView()
        {
            DetalleGridView.DataSource = (DataTable)ViewState["Detalle"];
            DetalleGridView.DataBind();

            ResumenGridView.DataSource = (DataTable)ViewState["Resumen"];
            ResumenGridView.DataBind();
        }
        public void LlenarDrowList()
        {
            DataTable dt = new DataTable();
            Trabajos tra = new Trabajos();
         
            dt = tra.Listado("*", "0=0", "ORDER BY Descripcion");
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                TrabajoDropDownList.Items.Add(Convert.ToString(tra.Listado("*", "0=0", "ORDER BY Descripcion").Rows[i]["Descripcion"]));
        }
        public bool CamposBacios()
        {
            bool Retornar = false;
            if(string.IsNullOrWhiteSpace(ClienteTextBox.Text) || DetalleGridView.Rows.Count == 0 || string.IsNullOrWhiteSpace(TotalTextBox.Text))
            {
                Retornar = true;
            }
            else
            {
                
            }
            return Retornar;
        }      
        public void ObtenerValores(Proyectos Pro)
        {
          
            Pro.Fecha = FechaTextBox.Text;
            Pro.Total = ConvertirTotal();
            Pro.ClienteId = ConvertirId();
     

            foreach(GridViewRow row in DetalleGridView.Rows)
            {
                Pro.AgregarTrabajos(1, row.Cells[0].Text, Convert.ToSingle(row.Cells[1].Text), Convert.ToSingle(row.Cells[2].Text),Convert.ToSingle(row.Cells[3].Text), Convert.ToSingle(row.Cells[4].Text));
           
            }

        }
        public void LlenarValores(Proyectos pro)
        {
            DataTable dt = (DataTable)ViewState["Detalle"];
            BuscarClienteTextBox.Text = pro.ClienteId.ToString();
            FechaTextBox.Text = pro.Fecha.ToString();
            TotalTextBox.Text = pro.Total.ToString();

            foreach(var item in pro.Detalle)
            {
                dt.Rows.Add(item.Descripcion, item.Ancho, item.Altura, item.Pie, item.Precio);
                ViewState["Detalle"] = dt;
                ObtenerGridView();
            }

        }
        public float Total()
        {            
           float total = DetalleGridView.Rows.Cast<GridViewRow>().Sum(x => Convert.ToSingle(x.Cells[4].Text));    
            return total;
        } 
        public void Limpiar()
        {
            ClienteTextBox.Text = "";           
            BuscarClienteTextBox.Text = "";
            TotalTextBox.Text = "";
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();


        }

        public void CalcularArea(DataTable dt)
        {
            foreach(DataRow row in dt.Rows)
            {

            }
        }
        protected void BuscarClienteButton_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();

            if(string.IsNullOrWhiteSpace(BuscarClienteTextBox.Text))
            {

            }else
            {
               if (cli.Buscar(ConvertirId()))
                {
                    ObtenerDatosCliente(cli);
                }else
                {
                    Utilitarios.ShowToastr(this, "Cliente No Existe", "Mensaje", "error");
                }

            }
        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            
            Trabajos tra = new Trabajos();
            Proyectos pro = new Proyectos();
           
            float Precio = 0;
     
            //ViewState
          
            try
            {
                DataTable dt = (DataTable)ViewState["Detalle"];
                 DataRow row;
                row = dt.NewRow();
             
                row["Descripcion"] = TrabajoDropDownList.Text;
                row["Ancho"] = AnchoTextBox.Text;
                row["Altura"] = AlturaTextBox.Text;
                row["Pie"] = tra.ObtenerPie(TrabajoDropDownList.Text);
                Precio= pro.Precio(AnchoTextBox.Text,AlturaTextBox.Text,TrabajoDropDownList.Text);                            
                row["Precio"] = Precio;               
                dt.Rows.Add(row);
                ViewState["Detalle"] = dt;

                          
      
                TrabajoDropDownList.Items.Clear();
                LlenarDrowList();
                AnchoTextBox.Text = "";
                AlturaTextBox.Text = "";

                DataTable dt2 = (DataTable)ViewState["Resumen"];
                DataRow row2;
                row2 = dt2.NewRow();
                bool Exist = false;

                foreach(DataRow item in dt2.Rows)
                {
                    if (item["Descripcion"].ToString() == row["Descripcion"].ToString())
                    {
                        item["AnchoTotal"] = Convert.ToSingle(item["AnchoTotal"].ToString()) + Convert.ToSingle(row["Ancho"]);
                        item["AlturaTotal"] = Convert.ToSingle(item["AlturaTotal"].ToString()) + Convert.ToSingle(row["Altura"]);
                        item["PieTotal"] = Convert.ToSingle(item["PieTotal"].ToString()) + Convert.ToSingle(row["Pie"]);
                        Exist = true;
                    }
                }

                if (!Exist)
                {
                    row2["Descripcion"] = row["Descripcion"];
                    row2["AnchoTotal"] = row["Ancho"];
                    row2["AlturaTotal"] = row["Altura"];
                    row2["PieTotal"] = row["Pie"];
                    dt2.Rows.Add(row2);
                }
               
                ViewState["Resumen"] = dt2;
                ObtenerGridView();
          TotalTextBox.Text = Total().ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        protected void DetalleGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //decimal Total = 0;
          
            //if(e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Total += DataBinder.Eval(e.Row.DataItem,"Precio");
            //}else if(e.Row.RowType == DataControlRowType.Footer)
            //{
            //    e.Row.Cells[6].Text = Total.ToString();
            //}
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Proyectos pro = new Proyectos();
      
            ObtenerValores(pro);

            if (CamposBacios())
            {
                Utilitarios.ShowToastr(this, "Error", "Mensaje", "error");
            }
            else
            {
                if (BuscarIdTextBox.Text=="")
                {


                    if (pro.Insertar())
                    {
                        
                    }
                }
                else
                {
                    if (pro.Editar())
                    {
                        
                    }
                }
                Utilitarios.ShowToastr(this, "Guardado", "Mensaje", "success");
            }
            
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Proyectos pro = new Proyectos();
            if(string.IsNullOrWhiteSpace(BuscarClienteTextBox.Text))
            {
                Utilitarios.ShowToastr(this, "Error", "Mensaje", "error");
            }
            else
            {
                if(pro.Eliminar())
                {
                    Utilitarios.ShowToastr(this, "Eliminado", "Mensaje", "success");
                    Limpiar();
                }
            }
        }

        protected void LimpiarButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarProyectoButton_Click(object sender, EventArgs e)
        {
            TrabajoDropDownList.Items.Clear();
            LlenarDrowList();
            Proyectos pro = new Proyectos();
            if(string.IsNullOrWhiteSpace(BuscarIdTextBox.Text))
            {

            }
            else
            {

                if(pro.Buscar(ConvertirIdProyecto()))
                {
                    LlenarValores(pro);

                }
                else
                {
                    Utilitarios.ShowToastr(this, "Id Incorrecto", "Mensaje", "error");
                }
            }
        }
    }
}