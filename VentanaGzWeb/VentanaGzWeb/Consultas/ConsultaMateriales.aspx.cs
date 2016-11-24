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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string Text = "";
            string orden = "";

            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text) && MaterialesDropDownList.Text != "Todos Los Materiales")
            {
                Utilitarios.ShowToastr(this, "Campo Buscar Vacio", "Mensaje", "error");
            }
            else
            {
                if (MaterialesDropDownList.Text == "Nombre")
                {
                    Text = " Where Detalle = ";
                    orden = BuscarTextBox.Text;
                }
                else if (MaterialesDropDownList.Text == "Todos Los Materiales")
                {
                    Text = "--";
                    orden = "--";
                }
                else if (MaterialesDropDownList.Text == "Id")
                {
                    Text = " where MaterialId = ";
                    orden = BuscarTextBox.Text;
                }

                MaterialesGridView.DataSource = mate.Listado("*",Text,orden);
                MaterialesGridView.DataBind();
            }
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {

            MaterialesReportViewer.LocalReport.DataSources.Clear();
            MaterialesReportViewer.ProcessingMode = ProcessingMode.Local;
            

            MaterialesReportViewer.LocalReport.ReportPath = @"Reportes\MaterialesReport.rdlc";

            ReportDataSource source = new ReportDataSource("MaterialesDataSet", mate.Listado("*", " " ,"--"));

            MaterialesReportViewer.LocalReport.DataSources.Add(source);
            MaterialesReportViewer.LocalReport.Refresh();

        
        }
    }
}