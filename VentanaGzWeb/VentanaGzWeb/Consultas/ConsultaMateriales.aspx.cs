using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Microsoft.Reporting.WebForms;

namespace VentanaGzWeb.Consultas
{
    public partial class ConsultaMaeriales : System.Web.UI.Page
    {
        Materiales mate = new Materiales();
        public string Text { get; set; }
        public string Orden { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        public ConsultaMaeriales()
        {
            this.Text = "";
            this.Orden = "";
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text) && MaterialesDropDownList.Text != "Todos Los Materiales")
            {
                Utilitarios.ShowToastr(this, "Campo Buscar Vacio", "Mensaje", "error");
            }
            else
            {
                Ordenes();
                MaterialesGridView.DataSource = mate.Listado("*", this.Text, this.Orden);
                MaterialesGridView.DataBind();
            }
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text) && MaterialesDropDownList.Text != "Todos Los Materiales")
            {
                Utilitarios.ShowToastr(this, "Campo Buscar Vacio", "Mensaje", "error");
            }
            else
            {

                Ordenes();

                Response.Write("<script type='text/javascript'>detailedresults=window.open('/Reportes/ReporteMaterialesWebForm.aspx?Text= " + this.Text + "&Orden= " + this.Orden+ "');</script>");

            }
        }
        public void Ordenes()
        {
            if (MaterialesDropDownList.Text == "Nombre")
            {
                this.Text = " Where Detalle = ";
                this.Orden = BuscarTextBox.Text;
            }
            else if (MaterialesDropDownList.Text == "Todos Los Materiales")
            {
                this.Text = "--";
                this.Orden = "--";
            }
            else if (MaterialesDropDownList.Text == "Id")
            {
                this.Text = " where MaterialId = ";
                this.Orden = BuscarTextBox.Text;
            }
        }
    }
}