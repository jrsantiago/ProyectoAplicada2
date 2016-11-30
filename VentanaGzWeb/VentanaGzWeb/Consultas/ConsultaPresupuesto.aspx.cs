using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace VentanaGzWeb.Consultas
{
    public partial class ConsultaPresupuesto : System.Web.UI.Page
    {
        public string Text { get; set; }
        public string Orden { get; set; }
        public ConsultaPresupuesto()
        {
            this.Text = "";
            this.Orden = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImprimirButton.Visible = false;

            }

        }
        public void OrdenInsert()
        {
            if (PresupuestoDropDownList.Text == "Proyecto Id")
            {
                this.Text = " where P.ProyectoId = ";
                this.Orden = BuscarTextBox.Text;
            }
            else if (PresupuestoDropDownList.Text == "Cliente Id")
            {
                this.Text = "where P.ClienteId= ";
                this.Orden = BuscarTextBox.Text;
            }

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Proyectos pro = new Proyectos();

                OrdenInsert();

           
                PresupuestoGridView.DataSource = pro.ListarPresupuesto("M.Detalle,SUM(O.Cantidad)AS Cantidad", this.Text, this.Orden);
                PresupuestoGridView.DataBind();

                
                ImprimirButton.Visible = true;

            if (PresupuestoGridView.Rows.Count == 0)
            {
                
                ImprimirButton.Visible = false;
                Utilitarios.ShowToastr(this, "Id incorrecto", "Mensaje", "error");
            }


        }
        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (PresupuestoGridView.Rows.Count == 0)
            {
                Utilitarios.ShowToastr(this, "Error", "Mensaje", "error");
            }
            else
            {

                OrdenInsert();

                Response.Write("<script type='text/javascript'>detailedresults=window.open('/Reportes/ReportePresupuestoWebForm.aspx?Text= " + this.Text + "&Orden= " + this.Orden + "');</script>");

            }
        }
    }
  }
